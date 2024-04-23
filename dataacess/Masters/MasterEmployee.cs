using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterEmployee :DBObject
    {

        //Insert Employee Details.
        //
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterEmployee()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertEmployeeDetails(string title, string employeename, string userid, string password, string dept, string desgn, string branch, DateTime doj, DateTime doc, DateTime dob, string bankname, string bankbranch, string accountno, string address, string phoneh, string phonehp, string email)
        {
            int deptid = GetDeptid(dept);
            int desgnid = GetDesgnid(desgn);

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@title",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@empname",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@username",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@pwd",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@deptid",SqlDbType.TinyInt,1),  
                                                                                     new SqlParameter("@desigid",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@branch",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@doj", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@doc", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@dob", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@bankname", SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@bankbranch", SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@accountno", SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@address", SqlDbType.VarChar,100),    
                                                                                     new SqlParameter("@phonehp", SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phoneres", SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@email", SqlDbType.VarChar,25)};

            objp[0].Value = title;
            objp[1].Value = employeename;
            objp[2].Value = userid;
            objp[3].Value = password;
            objp[4].Value = deptid;
            objp[5].Value = desgnid;
            objp[6].Value = branch;
            objp[7].Value = doj;
            objp[8].Value = doc;
            objp[9].Value = dob;
            objp[10].Value = bankname;
            objp[11].Value = bankbranch;
            objp[12].Value = accountno;
            objp[13].Value = address;
            objp[14].Value = phonehp;
            objp[15].Value = phoneh;
            objp[16].Value = email;
            ExecuteQuery("SPInsEmployeeDetails",objp);
                       
        }

        //Update Employee Details.  
        public void UpdateEmployeeDetails(int empid, string title, string empname, string username, string password, string dept, string desgn, string branch, DateTime doj, DateTime doc, DateTime dob, string bankname, string accountno, string bankbranch, string address, string phoneR, string phoneHP, string email)
        {
            int deptid = GetDeptid(dept);
            int desgnid = GetDesgnid(desgn);
            int eid = GetEmpid(username);

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@title",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@empname",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@username",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@pwd",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@deptid",SqlDbType.TinyInt,1),  
                                                                                     new SqlParameter("@desigid",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@branch",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@doj", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@doc", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@dob", SqlDbType.DateTime,8),
                                                                                     new SqlParameter("@bankname", SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@bankbranch", SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@accountno", SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@address", SqlDbType.VarChar,100),    
                                                                                     new SqlParameter("@phonehp", SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phoneres", SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@email", SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};

            objp[0].Value = title;
            objp[1].Value = empname;
            objp[2].Value = username;
            objp[3].Value = password;
            objp[4].Value = deptid;
            objp[5].Value = desgnid;
            objp[6].Value = branch;
            objp[7].Value = doj;
            objp[8].Value = doc;
            objp[9].Value = dob;
            objp[10].Value = bankname;
            objp[11].Value = bankbranch;
            objp[12].Value = accountno;
            objp[13].Value = address;
            objp[14].Value = phoneHP;
            objp[15].Value = phoneR;
            objp[16].Value = email;
            objp[17].Value = empid;

            ExecuteQuery("SPUpdEmployeeDetails", objp);
       
        }

       // Show Employee Details based on Username 
        public DataTable GetEmployeeDetails(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 10) };
            objp[0].Value = username;
            return ExecuteTable("SPSelEmployeeDetails", objp);
        }

        //Get Departmentid based on Departmentname. 
        public int GetDeptid(string deptname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptname", SqlDbType.VarChar, 30) };
            objp[0].Value = deptname;
            return int.Parse(ExecuteReader("SPDeptidDName",objp));
        }

        ////Get Departmentname based on Departmentid
        public string GetDeptName(int deptid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.TinyInt, 1) };
            objp[0].Value = deptid;
            return (ExecuteReader("SPDeptnameDId", objp));
        }

        ////Get Desgnname based on Desgnid.
        public string GetDesgnName(int desgnid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desigid", SqlDbType.TinyInt, 1) };
            objp[0].Value = desgnid;
            return ExecuteReader("SPDesignameDId", objp);
        }

        //Get Designationid based on Designationname.  
        public int GetDesgnid(string desgnname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30) };
            objp[0].Value = desgnname;
            return int.Parse(ExecuteReader("SPDesigidDName", objp));
        }

        //Get Employeeid based on username . 
        public int GetEmpid(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username",SqlDbType.VarChar,30) };
            objp[0].Value = username;
            return int.Parse(ExecuteReader("SPEmpidUsrName", objp));
        }

        //Get Employeeid based on username . 
        public int GetNEmpid(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empname", SqlDbType.VarChar, 50) };
            objp[0].Value = empname;

            return int.Parse(ExecuteReader("SPEmpidEmpName", objp));
        }

        //Get EmployeeName Basedon Employeeid.
        public string GetEmployeeName(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@employeeid", SqlDbType.Int) };
            objp[0].Value = employeeid;
            return ExecuteReader("SPEmpnameEmpId", objp);
           
        }


        public DataTable GetDept()
        {
            Cmd = new SqlCommand("select deptname from MasterDepartment", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Dept");
            return Ds.Tables["Dept"];
        }

        public DataTable GetBranch()
        {
            Cmd = new SqlCommand("select disnict a.portname as portname, b.branchname from MasterPort a,MasterBranch b where a.portid=b.portid", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Branch");
            return Ds.Tables["Branch"];
        }

        public DataTable GetDesign()
        {
            //Cmd = new SqlCommand("select designame from MasterDesignation where desigid not in (1,26,29) and designame <> '' order by designame", Conn);
            //Adp = new SqlDataAdapter(Cmd);
            //Ds = new DataSet();
            //Adp.Fill(Ds, "Design");
            //return Ds.Tables["Design"];



            SqlParameter[] objp = new SqlParameter[] {  };
          
            return ExecuteTable("SPGetDesigforHREmployee", objp);
        }


        // *******Methods For Windows Application.*********

        //Get Like Employee
        public DataTable GetLikeEmployee(string employeename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50) };
            objp[0].Value = employeename;
            return ExecuteTable("SPLikeEmployee",objp);
                   
        }

        public DataTable GetLikeUser(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtUser", SqlDbType.VarChar, 10) };
            objp[0].Value = username;
            return ExecuteTable("SPLikeuser", objp);
        }

        public DataTable GetPortNames()
        {
            Cmd = new SqlCommand("select a.portname from MasterPort a ,MasterEmployee b where a.portid = b.portid", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Port");
            return Ds.Tables["Port"];
        }

        public DataTable GetDivisionNames()
        {
            Cmd = new SqlCommand("select rtrim(divisionname) as divisionname from MasterDivision", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Division");
            return Ds.Tables["Division"];
        }
        public DataTable GetBranchName()
        {
            Cmd = new SqlCommand("select distinct a.portname as portname from MasterPort a,MasterBranch b where a.portid=b.portid", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "BranchName");
            return Ds.Tables["BranchName"];
        }
        public DataTable GetLikeEmployee4Systems(string employeename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50) };
            objp[0].Value = employeename;
            return ExecuteTable("SPLikeEmployee4systems", objp);

        }
        public string SelBranchHeadMailID(int DivisionID, string BranchName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@branchname", SqlDbType.VarChar, 15) };
            objp[0].Value = DivisionID;
            objp[1].Value = BranchName;
            return ExecuteReader("SPSelBranchHeadMailID", objp);
        }
        //--4 web start
        public DataSet GetEmployeeDetails4web(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 10) };
            objp[0].Value = username;
            return ExecuteDataSet("SPSelEmployeeDetails4Web", objp);
        }
        public DataTable GetEmpLeave4Profile(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 10) };
            objp[0].Value = username;
            return ExecuteTable("SPSelEmpLeaves4WebProfile", objp);
        }
        //--4 web end


        public DataTable GetBranchManagerMail(int branch, int division)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branch",SqlDbType.Int,4),
                new SqlParameter("@division",SqlDbType.Int,4)
            };
            objp[0].Value = branch;
            objp[1].Value = division;
            return ExecuteTable("SPGetBranchMailid", objp);
        }


        public DataTable GetUsernamefromid(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@empid",SqlDbType.Int,4)
            };
            objp[0].Value = empid;
            return ExecuteTable("SPgetusernamefromempid", objp);
        }

        public string GetEmployeePhoneNo(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = employeeid;
            return ExecuteReader("SPGetEmpPhoneNo", objp);

        }

        //Get Like Employee 4 Quotation
        public DataTable GetLikeEmployee4Quot(string employeename,int DivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@DivID", SqlDbType.TinyInt)};
            objp[0].Value = employeename;
            objp[1].Value = DivID;
            return ExecuteTable("SPLikeEmployee4Quot", objp);

        }

        //**************************************Elakkiya******************

        public DataTable GetEmployeeID(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@empname", SqlDbType.VarChar, 50) 
                                                     };
            objp[0].Value = empname;
            return ExecuteTable("SPEmpidEmpName", objp);
        }


        public string GetEmpNameNew(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@employeeid", SqlDbType.Int) };
            objp[0].Value = employeeid;

            return ExecuteReader("SPEmpnameEmpId", objp);

        }



        //Get Like Employee Sales Only
        public DataTable GetSalesLikeEmployeeFROMBooking(string employeename, string trantype, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.Int, 4)};
            objp[0].Value = employeename;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            return ExecuteTable("SPLikeEmployeeSALES", objp);

        }

        //Arun and Prabha 

        public DataTable GetLikeEmployee4CRM(string employeename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50) };
            objp[0].Value = employeename;
            return ExecuteTable("SPLikeEmployee4CRM", objp);

        }
        //MUTHU

        public DataTable GetLikeprocessname(string processname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Processname", SqlDbType.VarChar, 50) };
            objp[0].Value = processname;
            return ExecuteTable("[SPLikeProcessNameHR]", objp);

        }
        //MUTHU
        public DataTable GetLikeprocessid(string processname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Processname", SqlDbType.VarChar, 50) };
            objp[0].Value = processname;
            return ExecuteTable("[spgetprocessid]", objp);

        }


        // muthu

        public DataTable GetLikeprocessname()
        {
            Cmd = new SqlCommand("select Processid,Processname from masterprocess", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "SPProcessNameHR");
            return Ds.Tables["SPProcessNameHR"];


        }

        //muthu
        public DataTable INShrMEMPPROCEE(int empid, int processid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@processid",SqlDbType.TinyInt)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = processid;
            return ExecuteTable("SPHREmpNProcess", objp);

        }
        //MUTHU
        public DataTable DELhrMEMPPROCEE(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid",SqlDbType.Int)
                                                       
                                                      };
            objp[0].Value = empid;

            return ExecuteTable("SPDELHREmpNProcess", objp);

        }
        //MUTHU
        public DataTable GetHRMprocessid(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.VarChar, 50) };
            objp[0].Value = empid;
            return ExecuteTable("SPGETHREMPprocessid", objp);

        }

        //MUTHU

        public DataTable GetLikefunctionname(string name)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@name", SqlDbType.VarChar, 50) };
            objp[0].Value = name;
            return ExecuteTable("[SPLikeFunctionname]", objp);

        }
        public DataTable GetLikefunctionid(string functionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@functionid", SqlDbType.Int) };
            objp[0].Value = functionid;
            return ExecuteTable("[SPLikeFunctionid]", objp);

        }

        public DataTable GetDeptFunc()
        {
            Cmd = new SqlCommand("select functionid,name  from masterfunctions", Conn);
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "DeptFunc");
            return Ds.Tables["DeptFunc"];
        }

        //Dinesh

        public DataTable GetEmployeeDetailsnew(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@emp", SqlDbType.VarChar, 100) };
            objp[0].Value = username;
            return ExecuteTable("SPSelEmployeeDetailsnew", objp);
        }
        public DataTable GetSp_Likeprocessname()
        {
           //Cmd = new SqlCommand("select Processid,Processname,touchclogo from masterprocess where touchclogo is not null", Conn);
           // Cmd = new SqlCommand("select Processid,Processname,touchclogo from masterprocess where touchclogo is not null", Conn);
           // Adp = new SqlDataAdapter(Cmd);
           // Ds = new DataSet();
           // Adp.Fill(Ds, "sp_masterprocessimages");
           // return Ds.Tables["sp_masterprocessimages"];

         
            return ExecuteTable("sp_masterprocessimages");
        }
        public DataTable sp_getname(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cusname", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("sp_getname", objp);

        }

        public void getInsUserrightsfromFunctionidinMasters(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
             ExecuteQuery("SPInsUserrightsfromFunctionidinMasters", objp);
        }

        //Dinesh

        public DataTable GetLikeEmployee4CRMCorn(string employeename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50) };
            objp[0].Value = employeename;
            return ExecuteTable("SPLikeEmployee4CRMcorn", objp);

        }
        public DataTable Get_Salespersonname(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@employeeid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("GetSalespersonname", objp);

        }


        public int GetEmpidphone(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 10) };
            objp[0].Value = username;
            return int.Parse(ExecuteReader("SPEmpidUsrNamephone", objp));
        }

        public int GetEmpidemployeeid(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 100) };
            objp[0].Value = username;
            return int.Parse(ExecuteReader("SPEmpidUsrNameoffmailid", objp));
        }
        public DataTable GetLikeEmployeenewsalesdet(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeEmployeenewsalesperson", objp);

        }


        public DataTable Sp_GetEmployenamedetails(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("Sp_GetEmployename", objp);

        }
        public DataTable GetSp_LikeprocessnameROLES()
        {
            //Cmd = new SqlCommand("select Processid,Processname,touchclogo from masterprocess where touchclogo is not null", Conn);
            // Cmd = new SqlCommand("select Processid,Processname,touchclogo from masterprocess where touchclogo is not null", Conn);
            // Adp = new SqlDataAdapter(Cmd);
            // Ds = new DataSet();
            // Adp.Fill(Ds, "sp_masterprocessimages");
            // return Ds.Tables["sp_masterprocessimages"];


            return ExecuteTable("sp_masterprocessROLES");
        }
        public DataTable GetLikeEmployeeTaskDashBord(string employeename, int DivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@DivID", SqlDbType.TinyInt)};
            objp[0].Value = employeename;
            objp[1].Value = DivID;
            return ExecuteTable("SPLikeEmployee4Taskdash", objp);

        }
        public DataTable GetSalesPersonCustomer(int Salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@saleid", SqlDbType.Int) };
            objp[0].Value = Salesid;
            return ExecuteTable("SP_GetSalesPersonCustomer", objp);

        }

    }
}
