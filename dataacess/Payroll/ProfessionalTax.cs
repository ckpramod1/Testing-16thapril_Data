using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.payroll
{
    public class ProfessionalTax : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ProfessionalTax()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetAllBranches(string division)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@divisionname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = division;
            return ExecuteTable("SPSelAllBranches", objp);
        }
       /* public void SveProfTax(int bid, double slapfrm, double slapto, double taxamt,System.Windows.Forms.ListView lv,DateTime validfrom,DateTime validto )
        {
           
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = taxamt;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            int tmp_Tid= ExecuteQuery("SPInsProfTax", objp,"@Tid");

            for (int i = 1; i <= lv.Items.Count  ; i++)
            {
                if (lv.Items[i-1].Checked == true)
                {
                     objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                    objp[0].Value = tmp_Tid;
                    objp[1].Value = i ;
                    ExecuteQuery("SPInsProfTaxDet", objp);

                }

            }
        }*/

     /*   public void UpdateProfTax(int tid, int bid, double slabfrm, double slabto, double taxamt, System.Windows.Forms.ListView lv, DateTime validfrom, DateTime validto)
        {
           
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = taxamt;
            objp[4].Value = tid;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            int tmp_Tid= ExecuteQuery("SPUpdateProfTax", objp,"@Tid");

            for (int i = 1; i <= lv.Items.Count  ; i++)
            {
                if (lv.Items[i-1].Checked == true)
                {
                     objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                    objp[0].Value = tid;
                    objp[1].Value = i ;
                    ExecuteQuery("SPInsProfTaxDet", objp);

                }

            }
        }*/

        public double GetProfTaxAmt4Mum(int bid, int amt, int month, int year, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
             { 
                 new SqlParameter("@bid", SqlDbType.Int,4),
                 new SqlParameter("@amt", SqlDbType.Int,4),
                 new SqlParameter("@month", SqlDbType.TinyInt,2),
                 new SqlParameter("@year", SqlDbType.Int,4),
                 new SqlParameter("@empid", SqlDbType.Int,4)

                };
            objp[0].Value = bid;
            objp[1].Value = amt;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = empid;
            return double.Parse(ExecuteReader("SPGetProfTaxAmt4mum", objp));
        }


       /* public void SveProfTax(int bid, double slapfrm, double slapto, double taxamt, string[] lv, DateTime validfrom, DateTime validto, char charcategory)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                    new SqlParameter("@category",SqlDbType.Char ,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = taxamt;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            objp[7].Value = charcategory;
            int tmp_Tid = ExecuteQuery("SPInsProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {
                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tmp_Tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);



            }
        }*/

        public void SveProfTax(int bid, double slapfrm, double slapto, double taxamt, string[] lv, DateTime validfrom, DateTime validto, char charcategory)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.Int),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                    new SqlParameter("@category",SqlDbType.Char ,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = taxamt;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            objp[7].Value = charcategory;
            int tmp_Tid = ExecuteQuery("SPInsProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {
                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tmp_Tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);



            }
        }

      /*  public void UpdateProfTax(int tid, int bid, double slabfrm, double slabto, double taxamt, string[] lv, DateTime validfrom, DateTime validto, char charcategory)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                  new SqlParameter("@category",SqlDbType.Char ,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = taxamt;
            objp[4].Value = tid;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            objp[7].Value = charcategory;
            int tmp_Tid = ExecuteQuery("SPUpdateProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {

                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);

            }
        }*/
        public DataTable SelProfTax(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = bid;
            return ExecuteTable("SPSelProfTax", objp);
        }

        public DataTable SelProfTaxDet(int Tid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = Tid;
            return ExecuteTable("SPSelProfTaxDet", objp);
        }

        //public double GetProfTaxAmt(int bid,int amt,int month)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@bid", SqlDbType.Int,4),
        //        new SqlParameter("@amt", SqlDbType.Int,4),
        //        new SqlParameter("@month", SqlDbType.Int,4)
                                                       
        //       };
        //    objp[0].Value = bid;
        //    objp[1].Value = amt;
        //    objp[2].Value = month;
        //    return double.Parse(ExecuteReader("SPGetProfTaxAmt", objp));
        //}
        public double GetProfTaxAmt(int bid, int amt, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter("@amt", SqlDbType.Int,4),
                new SqlParameter("@month", SqlDbType.TinyInt,2),
                new SqlParameter("@year", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = bid;
            objp[1].Value = amt;
            objp[2].Value = month;
            objp[3].Value = year;
            return double.Parse(ExecuteReader("SPGetProfTaxAmt", objp));
        }

        //use for report on ProfTax


        public DataTable GetProfTax(int dtmonth, int dtyear)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@dtmonth",SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4)};

           
            objp[0].Value = dtmonth;
            objp[1].Value = dtyear;
            return ExecuteTable("SPGetProfTax", objp);
        }

        public void DelProfTax(int tid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tid", SqlDbType.Int) };
            objp[0].Value = tid;
            ExecuteQuery("SPDelProfTax", objp);
        }


        public DataTable GetProfTaxMonth(int bid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter("@month", SqlDbType.TinyInt,2),
                new SqlParameter("@year", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = bid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetProfTaxMonth", objp);
        }
        public DataTable GetEmployeeDtls(string name)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@ename",SqlDbType.VarChar,30)
                        };
            objp[0].Value = name;
            return ExecuteTable("SPGetEmpnameDtls", objp);

        }
        public DataTable GetAllBranches4HR(string division/*, string fname*/)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@divisionname",SqlDbType.VarChar,30)
                           // new SqlParameter("@fname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = division;
            //objp[1].Value = fname;
            return ExecuteTable("SPSelAllBranches4HR", objp);
        }

        /*Dinesh*/

        public void SveProfTaxWeb(int bid, double slapfrm, double slapto, double taxamt, string[] lv, DateTime validfrom, DateTime validto)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = taxamt;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            int tmp_Tid = ExecuteQuery("SPInsProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {
                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tmp_Tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);



            }
        }
        public void UpdateProfTaxWeb(int tid, int bid, double slabfrm, double slabto, double taxamt, string[] lv, DateTime validfrom, DateTime validto)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.Int),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = taxamt;
            objp[4].Value = tid;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            int tmp_Tid = ExecuteQuery("SPUpdateProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {

                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);

            }

        }



        public void UpdateProfTax(int tid, int bid, double slabfrm, double slabto, double taxamt, string[] lv, DateTime validfrom, DateTime validto, char charcategory)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@taxamt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.Int),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                  new SqlParameter("@category",SqlDbType.Char ,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = taxamt;
            objp[4].Value = tid;
            objp[5].Value = validfrom;
            objp[6].Value = validto;
            objp[7].Value = charcategory;
            int tmp_Tid = ExecuteQuery("SPUpdateProfTax", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {

                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsProfTaxDet", objp);

            }
        }


    }

}
