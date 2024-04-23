using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
    public class PayrollProcess : DBObject
    {
        int intEmpID;



        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public PayrollProcess()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetlistEmpCode4branch(int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@bid", SqlDbType.Int)                
            };
            objp[0].Value = bid ;
            return ExecuteTable("SPSelListEmpCode", objp);
        }

        public DataTable  GetLopDates(int empid,int LopMonth,int LopYear)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@employeeid", SqlDbType.Int),
                new SqlParameter("@month", SqlDbType.TinyInt, 2),
                new SqlParameter("@year", SqlDbType.Int) 
            };
            objp[0].Value = empid;
            objp[1].Value = LopMonth;
            objp[2].Value = LopYear;
            //return Convert.ToDouble(ExecuteReader("SPGetLopDays", objp));
            return ExecuteTable("SPGetLopDays", objp);
        }
        public DataTable GetEmp4Division(int divid,DateTime  payDate)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@Date", SqlDbType.SmallDateTime),
                new SqlParameter("@DivId", SqlDbType.Int)
                              
            };
            objp[0].Value = payDate;
            objp[1].Value = divid;
            return ExecuteTable("SPPRSelEmp4Division", objp);  
        }

        public DataTable GetEmp4OneEemp(string strEmpCode, DateTime payDate)
        {
            intEmpID = empObj.GetEmpid(strEmpCode);
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@Date", SqlDbType.SmallDateTime),
                new SqlParameter("@empid", SqlDbType.Int) 
                              
            };
            objp[0].Value = payDate;
            objp[1].Value = intEmpID;
            return ExecuteTable("spPRSelEmp4OneEmp", objp);
        }
        public DataTable GetEmpSalaryDetails(int empid,DateTime PRDate)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@PRDate", SqlDbType.SmallDateTime),
                new SqlParameter("@empid", SqlDbType.Int)                
            };
            objp[0].Value = PRDate;
            objp[1].Value = empid ;
            return ExecuteTable("SPPRSelEmpSalaryDetails", objp);
        }

        public DataTable GetEmpDeducationDetails(int empid, DateTime PRDate)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@PRDate", SqlDbType.SmallDateTime),
                new SqlParameter("@empid", SqlDbType.Int)                
            };
            objp[0].Value = PRDate;
            objp[1].Value = empid;
            return ExecuteTable("SPPRSelEmpDedDetails", objp);
        }

        public DataTable GetEmpLoanDetails(int empid, DateTime PRDate)
        {
            SqlParameter[] objp = new SqlParameter[]            { 
                new SqlParameter("@SalDate", SqlDbType.DateTime) ,
                new SqlParameter("@empid", SqlDbType.Int) 
               
            };
            objp[0].Value = PRDate;
            objp[1].Value = empid;
            //return ExecuteTable("SPPRSelEmpLoanDetails", objp);
             return ExecuteTable("SPGetLoanBalance", objp);
        }
        public DataTable GetEmpAllAllowanceDetails(int empid, DateTime PRDate)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@PRDate", SqlDbType.SmallDateTime),
                new SqlParameter("@empid", SqlDbType.Int)                
            };
            objp[0].Value = PRDate;
            objp[1].Value = empid;
            return ExecuteTable("SPPRSelEmpAllAllowanceDetails", objp);
        }
 
        //public void SavePayrollProcessdet(DataTable dt,int month,int year)
        //{
        //    SqlParameter[] objp;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
                
        //        objp = new SqlParameter[]
        //        {
        //            new SqlParameter("@empid",SqlDbType.Int),
        //            new SqlParameter("@paymonth", SqlDbType.TinyInt),
        //            new SqlParameter("@payyear", SqlDbType.Int)
        //        };
        //        objp[0].Value = dt.Rows[i]["empid"].ToString();
        //        objp[1].Value = month;
        //        objp[2].Value = year; //dt.Rows[i]["PAYYEAR"].ToString();
        //        ExecuteQuery("SPPRDelPayrollDet", objp);

        //        objp = new SqlParameter[]
        //        { 
        //            new SqlParameter("@empid", SqlDbType.Int),
        //            new SqlParameter("@paymonth", SqlDbType.TinyInt),
        //            new SqlParameter("@payyear", SqlDbType.Int),
        //            new SqlParameter("@basic", SqlDbType.Money),
        //            new SqlParameter("@hra", SqlDbType.Money),
        //            new SqlParameter("@conv", SqlDbType.Money),
        //            new SqlParameter("@spallow", SqlDbType.Money),
        //            new SqlParameter("@otherearn", SqlDbType.Money),
        //            new SqlParameter("@basicarr", SqlDbType.Money),
        //            new SqlParameter("@otherarr", SqlDbType.Money),
        //            new SqlParameter("@loyalty", SqlDbType.Money),
        //            new SqlParameter("@pf", SqlDbType.Money),
        //            new SqlParameter("@esi", SqlDbType.Money),
        //            new SqlParameter("@lwf", SqlDbType.Money),
        //            new SqlParameter("@loan", SqlDbType.Money),
        //            new SqlParameter("@otherded", SqlDbType.Money),
        //            new SqlParameter("@driverwages", SqlDbType.Money),
        //            new SqlParameter("@eallowance", SqlDbType.Money),
        //            new SqlParameter("@petrol", SqlDbType.Money),
        //            new SqlParameter("@emi", SqlDbType.Money),
        //            new SqlParameter("@mobile", SqlDbType.Money),
        //            new SqlParameter("@datacard", SqlDbType.Money),
        //            new SqlParameter("@residencephone", SqlDbType.Money),
        //             new SqlParameter("@itax", SqlDbType.Money) ,
        //             new SqlParameter("@proftax", SqlDbType.Money) ,                    
        //            new SqlParameter("@medical", SqlDbType.Money),
        //             //Newly Added 
        //             new SqlParameter("@design", SqlDbType.VarChar ,40),
        //             new SqlParameter("@dept", SqlDbType.VarChar ,40),
        //             new SqlParameter("@location", SqlDbType.VarChar ,25),
        //              new SqlParameter("@grade", SqlDbType.VarChar ,4),
        //             new SqlParameter("@cl", SqlDbType.Decimal),
        //             new SqlParameter("@sl", SqlDbType.Decimal  ),
        //             new SqlParameter("@el", SqlDbType.Decimal  )

        //        };
        //        objp[0].Value = dt.Rows[i]["Empid"].ToString();
        //        objp[1].Value = month;
        //        objp[2].Value = year; //dt.Rows[i]["PAYYEAR"].ToString();
        //        objp[3].Value = dt.Rows[i]["BASIC"].ToString();
        //        objp[4].Value = dt.Rows[i]["HRA"].ToString();
        //        objp[5].Value = dt.Rows[i]["CONVEYANCE"].ToString();
        //        objp[6].Value = dt.Rows[i]["SPECIAL ALLOWANCE"].ToString();
        //        objp[7].Value = dt.Rows[i]["OTHER EARNING"].ToString();
        //        objp[8].Value = dt.Rows[i]["BASIC ARR"].ToString();
        //        objp[9].Value = dt.Rows[i]["OTHER ARR"].ToString();
        //        objp[10].Value = dt.Rows[i]["LOYALITY"].ToString();
        //        objp[11].Value = dt.Rows[i]["PF"].ToString();
        //        objp[12].Value = dt.Rows[i]["ESI"].ToString();
        //        objp[13].Value = dt.Rows[i]["LWF"].ToString();
        //        objp[14].Value = dt.Rows[i]["LOAN - ADVANCE"].ToString();
        //        objp[15].Value = dt.Rows[i]["OTHER DED"].ToString();
        //        objp[16].Value = dt.Rows[i]["DRIVER WAGES"].ToString();
        //        objp[17].Value = dt.Rows[i]["ENTERTAIN ALLOWANCE"].ToString();
        //        objp[18].Value = dt.Rows[i]["PETROL"].ToString();
        //        objp[19].Value = dt.Rows[i]["EMI"].ToString();
        //        objp[20].Value = dt.Rows[i]["MOBILE"].ToString();
        //        objp[21].Value = dt.Rows[i]["DATACARD"].ToString();
        //        objp[22].Value = dt.Rows[i]["RESIDENCE PHONE"].ToString();
        //        objp[23].Value = dt.Rows[i]["IT"].ToString();
        //        objp[24].Value = dt.Rows[i]["proftax"].ToString();
        //        objp[25].Value = dt.Rows[i]["MEDICAL"].ToString();

        //        //Newly Added
        //        objp[26].Value = dt.Rows[i]["DESIGNATION"].ToString();
        //        objp[27].Value = dt.Rows[i]["DEPT"].ToString();
        //        objp[28].Value = dt.Rows[i]["LOCATION"].ToString();
        //        objp[29].Value = dt.Rows[i]["GRADE"].ToString();
        //        objp[30].Value = dt.Rows[i]["CL"].ToString();
        //        objp[31].Value = dt.Rows[i]["SL"].ToString();
        //        objp[32].Value = dt.Rows[i]["EL"].ToString();
        //        ExecuteQuery("SPPRSavePayrollDet", objp);
        //    }
        //}


        public void SavePayrollProcessdet(DataTable dt, int month, int year)
        {
            SqlParameter[] objp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                objp = new SqlParameter[]
                {
                    new SqlParameter("@empid",SqlDbType.Int),
                    new SqlParameter("@paymonth", SqlDbType.TinyInt),
                    new SqlParameter("@payyear", SqlDbType.Int)
                };
                objp[0].Value = dt.Rows[i]["empid"].ToString();
                objp[1].Value = month;
                objp[2].Value = year; //dt.Rows[i]["PAYYEAR"].ToString();
                ExecuteQuery("SPPRDelPayrollDet", objp);

                objp = new SqlParameter[]
                { 
                    new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@paymonth", SqlDbType.TinyInt),
                    new SqlParameter("@payyear", SqlDbType.Int),
                    new SqlParameter("@basic", SqlDbType.Money),
                    new SqlParameter("@hra", SqlDbType.Money),
                    new SqlParameter("@conv", SqlDbType.Money),
                    new SqlParameter("@spallow", SqlDbType.Money),
                    new SqlParameter("@otherearn", SqlDbType.Money),
                    new SqlParameter("@basicarr", SqlDbType.Money),
                    new SqlParameter("@otherarr", SqlDbType.Money),
                    new SqlParameter("@loyalty", SqlDbType.Money),
                    new SqlParameter("@pf", SqlDbType.Money),
                    new SqlParameter("@esi", SqlDbType.Money),
                    new SqlParameter("@lwf", SqlDbType.Money),
                    new SqlParameter("@loan", SqlDbType.Money),
                    new SqlParameter("@otherded", SqlDbType.Money),
                    new SqlParameter("@driverwages", SqlDbType.Money),
                    new SqlParameter("@eallowance", SqlDbType.Money),
                    new SqlParameter("@petrol", SqlDbType.Money),
                    new SqlParameter("@emi", SqlDbType.Money),
                    new SqlParameter("@mobile", SqlDbType.Money),
                    new SqlParameter("@datacard", SqlDbType.Money),
                    new SqlParameter("@residencephone", SqlDbType.Money),
                     new SqlParameter("@itax", SqlDbType.Money) ,
                     new SqlParameter("@proftax", SqlDbType.Money) ,                    
                    new SqlParameter("@medical", SqlDbType.Money),
                     //Newly Added 
                     new SqlParameter("@design", SqlDbType.VarChar ,40),
                     new SqlParameter("@dept", SqlDbType.VarChar ,40),
                     new SqlParameter("@location", SqlDbType.VarChar ,25),
                      new SqlParameter("@grade", SqlDbType.VarChar ,4),
                     new SqlParameter("@cl", SqlDbType.Decimal),
                     new SqlParameter("@sl", SqlDbType.Decimal  ),
                     new SqlParameter("@el", SqlDbType.Decimal  ),
                     new SqlParameter("@gr", SqlDbType.Money) ,                    
                    new SqlParameter("@grpf", SqlDbType.Money)

                };
                objp[0].Value = dt.Rows[i]["Empid"].ToString();
                objp[1].Value = month;
                objp[2].Value = year; //dt.Rows[i]["PAYYEAR"].ToString();
                objp[3].Value = dt.Rows[i]["BASIC"].ToString();
                objp[4].Value = dt.Rows[i]["HRA"].ToString();
                objp[5].Value = dt.Rows[i]["CONVEYANCE"].ToString();
                objp[6].Value = dt.Rows[i]["SPECIALALLOWANCE"].ToString();
                objp[7].Value = dt.Rows[i]["OTHEREARNING"].ToString();
                objp[8].Value = dt.Rows[i]["BASICARR"].ToString();
                objp[9].Value = dt.Rows[i]["OTHERARR"].ToString();
                objp[10].Value = dt.Rows[i]["LOYALITY"].ToString();
                objp[11].Value = dt.Rows[i]["PF"].ToString();
                objp[12].Value = dt.Rows[i]["ESI"].ToString();
                objp[13].Value = dt.Rows[i]["LWF"].ToString();
                objp[14].Value = dt.Rows[i]["LOANADVANCE"].ToString();
                objp[15].Value = dt.Rows[i]["OTHERDED"].ToString();
                objp[16].Value = dt.Rows[i]["DRIVERWAGES"].ToString();
                objp[17].Value = dt.Rows[i]["ENTERTAINALLOWANCE"].ToString();
                objp[18].Value = dt.Rows[i]["PETROL"].ToString();
                objp[19].Value = dt.Rows[i]["EMI"].ToString();
                objp[20].Value = dt.Rows[i]["MOBILE"].ToString();
                objp[21].Value = dt.Rows[i]["DATACARD"].ToString();
                objp[22].Value = dt.Rows[i]["RESIDENCEPHONE"].ToString();
                objp[23].Value = dt.Rows[i]["IT"].ToString();
                objp[24].Value = dt.Rows[i]["proftax"].ToString();
                objp[25].Value = dt.Rows[i]["MEDICAL"].ToString();

                //Newly Added
                objp[26].Value = dt.Rows[i]["DESIGNATION"].ToString();
                objp[27].Value = dt.Rows[i]["DEPT"].ToString();
                objp[28].Value = dt.Rows[i]["LOCATION"].ToString();
                objp[29].Value = dt.Rows[i]["GRADE"].ToString();
                objp[30].Value = Convert.ToDecimal(dt.Rows[i]["CL"].ToString());
                objp[31].Value = Convert.ToDecimal(dt.Rows[i]["SL"].ToString());
                objp[32].Value = Convert.ToDecimal(dt.Rows[i]["EL"].ToString());
                objp[33].Value = dt.Rows[i]["GR"].ToString();
                objp[34].Value = dt.Rows[i]["GRPF"].ToString();
                ExecuteQuery("SPPRSavePayrollDet", objp);
            }
        }
        public DataTable GetParyollDet( int paymonth,int payyear,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                
                    
                new SqlParameter("@paymonth" , SqlDbType.Int),
                new SqlParameter("@payYear", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            
            
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = @divisionid;
            return ExecuteTable("SPPRSelPayrollDetails", objp);
        }

        public double GetLWFAmt(int bid, int month, int year, string str_grade)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter("@month", SqlDbType.TinyInt,2),
                new SqlParameter("@year", SqlDbType.Int,4),
                new SqlParameter("@grade",SqlDbType.NVarChar,10)
                                                       
               };
            objp[0].Value = bid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = str_grade;
            return double.Parse(ExecuteReader("SPGetLWFAmt", objp));
        }
        public DataTable GetITTax(int empid, DateTime DtFrom, DateTime DtTo)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                {
                  new SqlParameter("@empid",SqlDbType.Int,4),
                    new SqlParameter("@DtFrom", SqlDbType.DateTime),
                    new SqlParameter("@DtTo", SqlDbType.DateTime)

                };
            objp[0].Value = empid;
            objp[1].Value = DtFrom;
            objp[2].Value = DtTo;
            return ExecuteTable("SPHRPayRollITCalc", objp);
        }

        public double GetGross4ProfTax(int empid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@from", SqlDbType.SmallDateTime) ,
                new SqlParameter("@to", SqlDbType.SmallDateTime) 
            };
            objp[0].Value = empid;
            objp[1].Value = from;
            objp[2].Value = to;
            return double.Parse(ExecuteReader("SPGetGross4ProfTax", objp));

        }
        public bool ChkLWFEmpcount(int bid, int month, int year)
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
            return bool.Parse(ExecuteReader("SPChkLWFEmpcount", objp));
        }

        //Basic Arrear

        public DataTable GetParyollDet4empmonthyear(int paymonth, int payyear, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                
                    
                new SqlParameter("@paymonth" , SqlDbType.Int),
                new SqlParameter("@payYear", SqlDbType.Int),
                new SqlParameter("@empid",SqlDbType.Int)
            };


            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = empid;
            return ExecuteTable("sp_getHrPayroll4empmonthyear", objp);
        }

        public DataTable GetEffdate(int empid, DateTime efrom)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@empid",SqlDbType.Int),
                new SqlParameter("@effdt", SqlDbType.SmallDateTime) 
            };
            objp[0].Value = empid;
            objp[1].Value = efrom;
            return ExecuteTable("SPGetEffect", objp);
        }
        public DataTable GetEmp4LeaveDtls(int empid, int intYear)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid", SqlDbType.Int),              
                new SqlParameter("@year", SqlDbType.Int) 
            };
            objp[0].Value = empid;
            objp[1].Value = intYear;
            //return Convert.ToDouble(ExecuteReader("SPGetLopDays", objp));
            return ExecuteTable("SPGet4EmpLeaveDtls", objp);
        }

        public DataTable GetITax4Monthyearbranch(int divisionid, int portid, int year, int month, string type)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@portid", SqlDbType.Int) ,
                new SqlParameter("@Payyear",SqlDbType.Int),
                new SqlParameter("@PayMonth",SqlDbType.Int),
                new SqlParameter ("@rpttype",SqlDbType.VarChar,10)
            };
            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = year;
            objp[3].Value = month;
            objp[4].Value = type;
            return ExecuteTable("SPGetITax4monthyearbranch", objp);
        }



        public DataTable spgetempdet()
        {
            return ExecuteTable("spgetempdet");
        }

        public void SpRunpfforinvest()
        {
            ExecuteQuery("SpInsInvestmentDetails");
        }

        public DataTable GetTmpForm16(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = divisionid;
            return ExecuteTable("spgenerateForm16New", objp);
        }
        public DataTable DelLopDaysEmployee(int empid, int lopmonth, int lopyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@empid",SqlDbType.Int ),
                new SqlParameter("@lopmonth",SqlDbType.Int ),
                new SqlParameter("@lopyear",SqlDbType.Int ),
            };
            objp[0].Value = empid;
            objp[1].Value = lopmonth;
            objp[2].Value = lopyear;
            return ExecuteTable("spDelLopDaysEmployee", objp);
        }
        //RAJA FOR NTFORM16
        public DataTable GetTmpForm16NT(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = divisionid;
            return ExecuteTable("spgenerateForm16NonIT", objp);
        }
        //ManiG
        public DataTable GetTmpForm16NTWithNonIT(int divisionid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@divisionid",SqlDbType.Int),
                 new SqlParameter("@fdate", SqlDbType.DateTime),
                    new SqlParameter("@tdate", SqlDbType.DateTime)
            };
            objp[0].Value = divisionid;
            objp[1].Value = from;
            objp[2].Value = to;

            return ExecuteTable("spgenerateForm16NonITNew1415", objp);
        }
        public DataTable GetTmpForm16WithIT(int divisionid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            {   
                new SqlParameter("@divisionid",SqlDbType.Int),
                 new SqlParameter("@fdate", SqlDbType.DateTime),
                    new SqlParameter("@tdate", SqlDbType.DateTime)
            };
            objp[0].Value = divisionid;
            objp[1].Value = from;
            objp[2].Value = to;

            return ExecuteTable("spgenerateForm16New1415", objp);
        }
        public DataTable GetEmpHRADetails(int empid, DateTime PRDate)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@PRDate", SqlDbType.SmallDateTime),
                new SqlParameter("@empid", SqlDbType.Int)                
            };
            objp[0].Value = PRDate;
            objp[1].Value = empid;
            return ExecuteTable("spPRSelEmpHraDetails", objp);
        }
    }
}