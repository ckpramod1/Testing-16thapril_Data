using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{

    public partial class UserPermission : DBObject
    {
        //SqlCommand cmd;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public UserPermission()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetMenuName(string module)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@module", SqlDbType.VarChar, 2) };
            objp[0].Value = module;
            return ExecuteTable("SPGetMenuName", objp);
        }
     
        public DataTable GetFrmName(string module, string menu)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@module",SqlDbType.VarChar,2),                                                       
                                                       new SqlParameter("@menu",SqlDbType.VarChar,50)};
            objp[0].Value = module;
            objp[1].Value = menu;
            return ExecuteTable("SPGetFrmName", objp);
        }
        public DataTable GetMasterUI(int uiid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@uiid",SqlDbType.Int)};
            objp[0].Value = uiid;
            return ExecuteTable("SPGetMasterUI", objp);
        }
        public int GetUiid(string module, string menu, string uicaption)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@module",SqlDbType.VarChar,2),                                                       
                                                       new SqlParameter("@menu",SqlDbType.VarChar,50),                                                       
                                                       new SqlParameter("@uicaption",SqlDbType.VarChar,50)};
            objp[0].Value = module;
            objp[1].Value = menu;
            objp[2].Value = uicaption;
            return int.Parse(ExecuteReader("SPGetUiid", objp));
        }

        public void InsertUserRights(int empid, int uiid, int branchid, string trantype, int menuaccess, int uiaccess, int btnsave, int btnview, int btndelete, int btnupdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter ("@menuaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@uiaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnsave",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnview",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btndelete",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnupdate",SqlDbType.TinyInt,1),
                                                       
                                                     };
            objp[0].Value = empid;
            objp[1].Value = uiid;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = menuaccess;
            objp[5].Value = uiaccess;
            objp[6].Value = btnsave;
            objp[7].Value = btnview;
            objp[8].Value = btndelete;
            objp[9].Value = btnupdate;
            ExecuteQuery("SPInsUserRights", objp);
        }
        
        public void DeleteUserRights(int empid, int uiid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = empid;
            objp[1].Value = uiid;
            objp[2].Value = branchid;
            ExecuteQuery("SPDelUserRights", objp);
        }
        public DataTable GetUserRights(int empid, string module, string menu, string uicaption, string uiname,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@module",SqlDbType.VarChar,2),
                                                       new SqlParameter("@menu",SqlDbType.VarChar,50),
                                                       new SqlParameter("@uicaption",SqlDbType.VarChar,50),
                                                       new SqlParameter("@uiname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = module;
            objp[3].Value = menu;
            objp[4].Value = uicaption;
            objp[5].Value = uiname;
            return ExecuteTable("SPGetUserRights", objp);
        }

        public DataTable GetUserForTrantype(string trantype, string menuname, string submenuname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter ("@menuname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@submenuname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = menuname;
            objp[2].Value = submenuname;

            return ExecuteTable("SPGetUserForTrantype", objp);
        }
        public DataTable GetUserForEmpid(int empid, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            return ExecuteTable("SPGetUser", objp);
        }

        public DataTable GetUserForEB(int empid, int branchid, string trantype,string submenuname,int branch)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@submenuname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = submenuname;
            return ExecuteTable("SPGetUserRightsForEmpBranch", objp);
        }
        public DataTable GetUserForUiid(int empid, int branchid, string trantype, int uiid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@uiid",SqlDbType.Int)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = uiid;
            return ExecuteTable("SPGetUserRightsforUiid", objp);
        }
      

        public int GetMLUiid(string trantype, string frmname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),                                                       
                                                       new SqlParameter("@frmname",SqlDbType.VarChar,50)};
            objp[0].Value = trantype;
            objp[1].Value = frmname;
            return int.Parse(ExecuteReader("SPGetMLUiid", objp));
        }
        public DataTable GetMLEmpid(int uiid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@uiid", SqlDbType.Int),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = uiid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetMLEmpid", objp);
        }


        public DataTable GetUserPerModule(int intEmpID, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branch",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;

            return ExecuteTable("SPGetUserPerMoodule", objp);
        }
        public DataTable GetUserPerMenu(int intEmpID, int intBranchID, string strTrantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branch",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;

            return ExecuteTable("SPGetUserPerMenu", objp);
        }
        public DataTable GetUserPerSubMenu(int intEmpID, int intBranchID, string strTrantype, string strMenu)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branch",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@menuname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;
            objp[3].Value = strMenu;
            return ExecuteTable("SPGetUserPerSubMenu", objp);
        }
        public DataTable GetBtnPermission(int intEmpID, int intBranchID, int intUIID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 2),
                                                       new SqlParameter("@branch",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@uiid",SqlDbType.Int)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            objp[2].Value = intUIID;
            return ExecuteTable("SPGetUPByUIID", objp);
        }
        
        public void InsAllUserRights(int branch,int division,int employeeid, string module,string menuname,string submenuname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branch", SqlDbType.Int),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@employeeid", SqlDbType.Int) ,
                                                       new SqlParameter("@module", SqlDbType.VarChar, 3) ,
                                                       new SqlParameter("@menu", SqlDbType.VarChar, 25) ,
                                                       new SqlParameter("@submenuname", SqlDbType.VarChar, 25)};

            objp[0].Value = branch;
            objp[1].Value = division;
            objp[2].Value = employeeid;
            objp[3].Value = module;
            objp[4].Value = menuname;
            objp[5].Value = submenuname;
            ExecuteQuery("SPInsAllUserRights", objp);
        }
        public DataSet GetEmpRgt(int intEmpID, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            return ExecuteDataSet("SPSelEmpRgt", objp);
        }

        public DataTable GetUserRights4Menu(int intEmpID, int intBranchID, string strTrantype, string strMenu)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branch",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@menuname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;
            objp[3].Value = strMenu;
            return ExecuteTable("GetUserRights4Menu", objp);
        }

        public DataTable GetUserRights4SubMenu(int intEmpID, int intBranchID, string strTrantype, string strMenu,string SubMenuname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branch",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@menuname",SqlDbType.VarChar,50),
                                                       new SqlParameter("@submenuname",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;
            objp[3].Value = strMenu;
            objp[4].Value = SubMenuname;
            return ExecuteTable("GetUserRights4SubMenu", objp);
        }

        //Dinesh

        public DataTable GetMenus(int intEmpID, string strTrantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int)
                                        };
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelMainmenuWithRights4webElaa", objp);
        }

        public DataTable Getmodule(int intEmpID, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@branch",SqlDbType.Int)
                                        };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelmoduleWithRights", objp);
        } 

        //Raj



        public DataTable GetMenusprocess(int intEmpID, string strTrantype, int intBranchID,int process)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int),
                                        new SqlParameter("@processid",SqlDbType.Int)};
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = process;
            return ExecuteTable("SPSelMainmenuWithRightsprocess", objp);
        }

        public DataTable Getmodule_process(int intEmpID, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@branch",SqlDbType.Int)
                                        };
            objp[0].Value = intEmpID;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelmoduleWithRights_process", objp);
        } //Sp_getuiid  Session["Process1"] = obj_Dt.Rows[0]["process"].ToString()
        //raj
        public string Getuiid(string module, int processid, string formname)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@module",SqlDbType.VarChar,3),
                                            new SqlParameter("@processid",SqlDbType.Int),
                                            new SqlParameter("@formname",SqlDbType.VarChar,20)
                                        };
            objp[0].Value = module;
            objp[1].Value = processid;
            objp[2].Value = formname;
            return ExecuteReader("Sp_getuiid", objp);
        }



        //Dinesh

        public DataTable GetFormwiseuserRights(int uiid, int empid, int branch,string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@uiid",SqlDbType.Int,4),
                                            new SqlParameter("@empid",SqlDbType.Int,4),
                                            new SqlParameter("@branch",SqlDbType.Int,4),
                                             new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                        };
            objp[0].Value = uiid;
            objp[1].Value = empid;
            objp[2].Value = branch;
            objp[3].Value = trantype;
            return ExecuteTable("SPSelFormwiseuserRights", objp);
        }


        public string Getprocessidbyname(string process)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@process",SqlDbType.VarChar,30)
                                        };
            objp[0].Value = process;
            return ExecuteReader("Sp_getuiidbyname", objp);
        }
        public int Get_countrycodebyid(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@branchid",SqlDbType.Int)
                                        };
            objp[0].Value = branchid;
            return Convert.ToInt32(ExecuteReader("Sp_getcountrycodebyid", objp));
        }

        //Raj
        public DataTable Getformuserrights(int intEmpID, string strTrantype, int intBranchID, int process,string menuname)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int),
                                        new SqlParameter("@processid",SqlDbType.Int),
                                        new SqlParameter("@menuname",SqlDbType.VarChar,30)};
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = process;
            objp[4].Value = menuname;
            return ExecuteTable("sp_getformuserrights", objp);
        }


        public DataTable sp_getprocessname(int processid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@processid",SqlDbType.Int),                                                       
                                                      };
            objp[0].Value = processid;

            return ExecuteTable("sp_getprocessnamenew", objp);
        }
        public DataTable sp_userrightsmis(int processid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@processid",SqlDbType.Int),                                                       
                                                      };
            objp[0].Value = processid;

            return ExecuteTable("sp_userrightsmisnew", objp);
        }
        public DataTable sp_userrights4ui(int empid, int processid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),                                                       
                                                       new SqlParameter("@processid",SqlDbType.Int)};
            objp[0].Value = empid;
            objp[1].Value = processid;
            return ExecuteTable("sp_userrights4uinew", objp);
        }
        public DataTable sp_userrights4uinew(int empid, int processid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),                                                       
                                                       new SqlParameter("@processid",SqlDbType.Int),
                                                       new SqlParameter("@branch",SqlDbType.Int)};
            objp[0].Value = empid;
            objp[1].Value = processid;
            objp[2].Value = branchid;

            return ExecuteTable("sp_userrights4uinew", objp);
        }



        public int sp_masteruiid(string trantype, string uicaption, int processid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@trantype",SqlDbType.VarChar),
                                         new SqlParameter("@uicaption",SqlDbType.VarChar),
                                         new SqlParameter("@processid",SqlDbType.Int)
                                        };
            objp[0].Value = trantype;
            objp[1].Value = uicaption;
            objp[2].Value = processid;
            return Convert.ToInt32(ExecuteReader("sp_masteruiid", objp));
        }
        public DataTable sp_getportnamecor(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.Int),                                                       
                                                      };
            objp[0].Value = branchid;

            return ExecuteTable("sp_getportnamecornew", objp);
        }

        public DataTable sp_masteruiidsales(string uicaption)
        {
            SqlParameter[] objp = new SqlParameter[]   
                                        {
                                         new SqlParameter("@uicaption",SqlDbType.VarChar)
                                        };
            objp[0].Value = uicaption;

            return ExecuteTable("sp_masteruiidsales", objp);
        }
        public void InsertUserRightsNEWUI(int empid, int uiid, int branchid, string trantype, int menuaccess, int uiaccess, int btnsave, int btnview)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter ("@menuaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@uiaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnsave",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnview",SqlDbType.TinyInt,1),
                                                     
                                                       
                                                     };
            objp[0].Value = empid;
            objp[1].Value = uiid;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = menuaccess;
            objp[5].Value = uiaccess;
            objp[6].Value = btnsave;
            objp[7].Value = btnview;

            ExecuteQuery("SPInsUserRightsNEWUI", objp);
        }


        //MUTHURAJ
        public void GETSPInsMASTERPROCESS(int processid, string processname, byte[] empphoto)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Processid", SqlDbType.Int, 4),
                                                       new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
                                                       new SqlParameter ("@touchclogo",SqlDbType.Image),
                                                       
                                                     
                                                       
                                                     };
            objp[0].Value = processid;
            objp[1].Value = processname;
            objp[2].Value = empphoto;


            ExecuteQuery("SPInsMASTERPROCESS", objp);
        }



        //Dinesh
        public DataTable GetformuserrightsnewMIS(int intEmpID, string strTrantype, int intBranchID, int process, string menuname)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int),
                                        new SqlParameter("@processid",SqlDbType.Int),
                                        new SqlParameter("@menuname",SqlDbType.VarChar,30)};
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = process;
            objp[4].Value = menuname;
            return ExecuteTable("sp_getformuserrightsnew", objp);
        }


        public string Get_allowed_user()
        {

            return ExecuteReader("SP_USERLIMT");
        }


        //Dinesh
        public DataTable GetformuserrightsnewOUT(int intEmpID, string strTrantype, int intBranchID, int process, string menuname)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int),
                                        new SqlParameter("@processid",SqlDbType.Int),
                                        new SqlParameter("@menuname",SqlDbType.VarChar,30)};
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = process;
            objp[4].Value = menuname;
            return ExecuteTable("sp_getformuserrightsoutnew", objp);
        }

        //Dinesh
        public DataTable GetformuserrightsMIMIS(int intEmpID, string strTrantype, int intBranchID, int process, string menuname)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int),
                                        new SqlParameter("@processid",SqlDbType.Int),
                                        new SqlParameter("@menuname",SqlDbType.VarChar,30)};
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = process;
            objp[4].Value = menuname;
            return ExecuteTable("sp_getformuserrightsMInew", objp);
        }

        public DataTable Get_maintenancerights(int empid, string mis)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@empid",SqlDbType.Int),
                                            new SqlParameter("@mis",SqlDbType.VarChar,3)
                                        };
            objp[0].Value = empid;
            objp[1].Value = mis;
            return ExecuteTable("SP_checkamenrights", objp);
        }




        public void insuserrightsall(int employeeidfrom, int employeeidto)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empidfrom", SqlDbType.Int),
                                                       new SqlParameter("@empidto", SqlDbType.Int)
                                                       };

            objp[0].Value = employeeidfrom;
            objp[1].Value = employeeidto;

            ExecuteQuery("spuserrightsall", objp);
        }


        public DataTable Get_downdocdeleterightsrights(int empid, string mis)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@empid",SqlDbType.Int),
                                            new SqlParameter("@mis",SqlDbType.VarChar,3)
                                        };
            objp[0].Value = empid;
            objp[1].Value = mis;
            return ExecuteTable("SP_checkdownloadrights", objp);
        }

        //Dinesh
        public DataTable empcount()
        {

            return ExecuteTable("SPempcount");
        }


        public DataTable getcheckrecloserights(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@empid",SqlDbType.Int)
                                           
                                        };
            objp[0].Value = empid;
          
            return ExecuteTable("SP_checkrecloserights", objp);
        }
        // yuvaraj
        public DataTable sp_masteruiidnew(string trantype, string uicaption, int processid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@trantype",SqlDbType.VarChar),
                                         new SqlParameter("@uicaption",SqlDbType.VarChar),
                                         new SqlParameter("@processid",SqlDbType.Int)
                                        };
            objp[0].Value = trantype;
            objp[1].Value = uicaption;
            objp[2].Value = processid;
             return ExecuteTable("sp_masteruiid", objp);
        }
        public int Get_countrycode(string branch)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@branch",SqlDbType.VarChar,30)
                                        };
            objp[0].Value = branch;
            return Convert.ToInt32(ExecuteReader("Sp_getcountrycode", objp));
        }

        public DataTable SelMainmenuWithRights4MIreport(int intEmpID, string strTrantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                        {
                                            new SqlParameter("@userid",SqlDbType.Int),
                                            new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                            new SqlParameter("@branch",SqlDbType.Int)
                                        };
            objp[0].Value = intEmpID;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelMainmenuWithRights4MIreport", objp);
        }
        public void DeleteUserRightsRoles(int empid, int uiid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@roleid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = empid;
            objp[1].Value = uiid;
            objp[2].Value = branchid;
            ExecuteQuery("SPDelUserRightsRole", objp);
        }
        public void InsertUserRightsRoles(int empid, int uiid, int branchid, string trantype, int menuaccess, int uiaccess, int btnsave, int btnview, int btndelete, int btnupdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@roleid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter ("@menuaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@uiaccess",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnsave",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnview",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btndelete",SqlDbType.TinyInt,1),
                                                       new SqlParameter ("@btnupdate",SqlDbType.TinyInt,1),

                                                     };
            objp[0].Value = empid;
            objp[1].Value = uiid;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = menuaccess;
            objp[5].Value = uiaccess;
            objp[6].Value = btnsave;
            objp[7].Value = btnview;
            objp[8].Value = btndelete;
            objp[9].Value = btnupdate;
            ExecuteQuery("SPInsUserRightsRole", objp);
        }
        public DataTable sp_userrights4uinewRole(int empid, int processid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@roleid",SqlDbType.Int),
                                                       new SqlParameter("@processid",SqlDbType.Int),
                                                       new SqlParameter("@branch",SqlDbType.Int)};
            objp[0].Value = empid;
            objp[1].Value = processid;
            objp[2].Value = branchid;

            return ExecuteTable("sp_userrights4uinewrole", objp);
        }
        public DataTable Getdimensionmailid()
        {

            return ExecuteTable("SpGetdimensionmailid");
        }
        public DataTable GetMLEmpprealrt(string strTrantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@strTrantype", SqlDbType.VarChar, 30) };
            objp[0].Value = strTrantype;
            return ExecuteTable("SpGetMLEmpprealrt", objp);
        }
    }
}



