using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace DataAccess.HR
{

    public class FrontPage : DBObject
    {
        DataAccess.HR.Employee HREmpObj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterPort PortObj = new DataAccess.Masters.MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FrontPage()
        {
            Conn = new SqlConnection(DBCS);
        }

        //public DataTable GetLikeEmpName(string strDivision, string strBranchName, string empname)
        //{
        //    int divisionid = 0;
        //    int branchid = 0;
        //    divisionid = HREmpObj.GetDivisionId(strDivision);
        //    branchid = PortObj.GetNPortid(strBranchName);

        //    SqlParameter[] objp = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@branch",SqlDbType.Int,4),
        //                    new SqlParameter("@division",SqlDbType.Int,4),
        //                    new SqlParameter("@empname",SqlDbType.VarChar,30)
        //                };
        //    objp[0].Value = branchid;
        //    objp[1].Value = divisionid;
        //    objp[2].Value = empname;
        //    return ExecuteTable("SPLikeEmpnameBranchDivision", objp);
        //}
        public DataTable GetLikeEmpName(int branchid, int divisionid, string empname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4),
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = empname;
            return ExecuteTable("SPEmpNameFormat", objp);
        }

        public DataTable GetLikeEmpName(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 30) };
            objp[0].Value = empname;
            return ExecuteTable("SPLikeEmployee", objp);
        }

        public void InsBudget(int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@month", SqlDbType.Int),
                                                       new SqlParameter("@year", SqlDbType.Int)};
            objp[0].Value = month;
            objp[1].Value = year;
            ExecuteQuery("SPInsBudget", objp);
        }
        public int GetNoofEmployees(string strDivision, string strBranchName)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = PortObj.GetNPortid(strBranchName);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            Dt = ExecuteTable("SPGetCountEmp", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }

        public int GetNoofConfirmEmp(string strDivision, string strBranchName)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = PortObj.GetNPortid(strBranchName);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            Dt = ExecuteTable("SPGetConfirmEmp", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public int GetDivisionNoofConfirmEmp(string strDivision)
        {
            int divisionid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = divisionid;
            Dt = ExecuteTable("SPGetDiviConfirmEmp", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }

        public int GetNoofTemporaryEmp(string strDivision, string strBranchName)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = PortObj.GetNPortid(strBranchName);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            Dt = ExecuteTable("SPGetTemporaryEmp", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public int GetDivisionNoofTemporaryEmp(string strDivision)
        {
            int divisionid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = divisionid;
            Dt = ExecuteTable("SPGetDiviTemporaryEmp", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }

        public DataTable GetPortName(string strDivision)
        {
            int divisionid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@divisionid",SqlDbType.Int,4)
                        };
            objp[0].Value = divisionid;
            return ExecuteTable("SPGetPortName", objp);
        }

        public DataTable GetCurrMonthConfirm()
        {
            return ExecuteTable("SPCurrMonthConfirm");
        }

        public DataTable GetCurrMonthBirth()
        {
            return ExecuteTable("SPCurrMonthBrithDay");
        }

        public DataTable GetEmpNameFromBranchDivision(string strDivision, string strBranchName)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = PortObj.GetNPortid(strBranchName);

            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetEmpNameBranchDivision", objp);
        }

        public DataTable GetDeptDetails(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empcode",SqlDbType.VarChar,10)
                        };
            objp[0].Value = empcode;
            return ExecuteTable("SPGetDeptDetails", objp);
        }
        public void InsMasterACCode(string strDivision, string strBranchName, int vouyear)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = HREmpObj.GetBranchId(divisionid, strBranchName);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.Int),
                                                           new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            ExecuteQuery("SPInsMasterACCode", objp);
        }
        public DataTable GetBranchInfo(int intBranchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = intBranchid;
            return ExecuteTable("SPGetBranchInfo", objp);

        }
        public DataTable GetLikeEmpName(string strDivision, string strBranchName, string empname)
        {
            int divisionid = 0;
            int branchid = 0;
            HREmpObj.GetDataBase(Clientcode);
            divisionid = HREmpObj.GetDivisionId(strDivision);
            branchid = PortObj.GetNPortid(strBranchName);

            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4),
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = empname;
            return ExecuteTable("SPEmpNameFormat", objp);
        }
        public DataTable GetALLEmpNameRelived(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 30) };
            objp[0].Value = empname;
            return ExecuteTable("SPAllEmployeeRelived2", objp);
        }


        public DataTable GetCurrMonthBirthdayNew()
        {
            return ExecuteTable("Sp_BirthdayListNew");
        }
        //Dinesh
        public DataSet getcountmaintenancehome()
        {
            return ExecuteDataSet("spcountmaintenance");
        }
        public string SpInEmpRole(string empname, string empdesc)
        {
            SqlParameter[] array = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@txtEmpDesc", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@roleid", SqlDbType.Int, 4),};
            array[0].Value = empname;
            array[1].Value = empdesc;
            array[2].Direction = ParameterDirection.Output;
            IDataParameter[] array2 = array;
            IDataParameter[] parameters = array2;
            return ExecuteQuery("SpInEmpRole", "@roleid", array2);
        }

        public DataTable SpUpEmpRole(string empname, string empdesc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@txtEmpDesc", SqlDbType.VarChar, 30)};
            objp[0].Value = empname;
            objp[1].Value = empdesc;
            return ExecuteTable("SpUpEmpRole", objp);
        }
        public DataTable SPGetRoledes(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 30) };
            objp[0].Value = empname;
            return ExecuteTable("SPGetRoledes", objp);
        }

    }
}

