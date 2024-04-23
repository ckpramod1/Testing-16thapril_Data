using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SystemDetails:DBObject 
    {
        HR.Employee branchobj = new HR.Employee();
        HR.Employee divobj = new HR.Employee();
        DataAccess.HR.Employee HREmpObj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterPort PortObj = new DataAccess.Masters.MasterPort();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public SystemDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsSystemDetail(string divisionname,string  branchname ,int userid,string pctype,string processor,string mb,string ram,string moniter,string harddisk,char fdd,string cd,string dvd,string datacable,string ipaddress )
        {
            int divisionid = divobj.GetDivisionId(divisionname);
            int  branchid = branchobj.GetBranchId(divisionid,branchname);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                                             new SqlParameter ("@userid",SqlDbType.Int,4),
                                                                             new SqlParameter("@pctype",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@processor",SqlDbType.VarChar,50),
                                                                             new SqlParameter("@mb",SqlDbType.VarChar,25),
                                                                             new SqlParameter("@ram",SqlDbType.VarChar,20),
                                                                             new SqlParameter("@moniter",SqlDbType.VarChar,25),
                                                                             new SqlParameter("@harddisk",SqlDbType.VarChar,15),
                                                                             new SqlParameter("@fdd",SqlDbType.Char,1),
                                                                             new SqlParameter("@cd",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@dvd",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@datacable",SqlDbType.VarChar,20),
                                                                             new SqlParameter("@ipaddress",SqlDbType.VarChar,20)};
            objp[0].Value = branchid;
            objp[1].Value =userid ;
            objp[2].Value =pctype ;
            objp[3].Value =processor ;
            objp[4].Value =mb ;
            objp[5].Value =ram ;
            objp[6].Value =moniter ;
            objp[7].Value =harddisk ;
            objp[8].Value =fdd ;
            objp[9].Value =cd ;
            objp[10].Value =dvd ;
            objp[11].Value =datacable ;
            objp[12].Value = ipaddress;
            ExecuteQuery("SPInsSystemDetails", objp);
             }
        public void UpdSystemDetails(string divisionname, string branchname, int userid, string pctype, string processor, string mb, string ram, string moniter, string harddisk, char fdd, string cd, string dvd, string datacable,string ipaddress)
       
        {
            int divisionid = divobj.GetDivisionId(divisionname );
            int branchid = branchobj.GetBranchId(divisionid,branchname );
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@branchid",SqlDbType.TinyInt,1),
                                                                             new SqlParameter ("@userid",SqlDbType.Int,4),
                                                                             new SqlParameter("@pctype",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@processor",SqlDbType.VarChar,50),
                                                                             new SqlParameter("@mb",SqlDbType.VarChar,25),
                                                                             new SqlParameter("@ram",SqlDbType.VarChar,20),
                                                                             new SqlParameter("@moniter",SqlDbType.VarChar,25),
                                                                             new SqlParameter("@harddisk",SqlDbType.VarChar,15),
                                                                             new SqlParameter("@fdd",SqlDbType.Char,1),
                                                                             new SqlParameter("@cd",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@dvd",SqlDbType.VarChar,1),
                                                                             new SqlParameter("@datacable",SqlDbType.VarChar,20),
                                                                             new SqlParameter("@ipaddress",SqlDbType.VarChar,20)};
            objp[0].Value = branchid;
            objp[1].Value =userid ;
            objp[2].Value =pctype ;
            objp[3].Value =processor ;
            objp[4].Value = mb ;
            objp[5].Value =ram ;
            objp[6].Value =moniter ;
            objp[7].Value =harddisk ;
            objp[8].Value =fdd ;
            objp[9].Value = cd ;
            objp[10].Value =dvd ;
            objp[11].Value =datacable ;
            objp[12].Value = ipaddress;
            ExecuteQuery("SPUpdSystemDetails", objp);
            


        }
        public DataTable GetSystemDetails(string divisionname ,string branchname,int userid)
        {
            int divisionid = divobj.GetDivisionId(divisionname);
            int branchid = branchobj.GetBranchId(divisionid, branchname);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@userid",SqlDbType.Int,4)};        
                                                                                                       
           objp[0].Value =branchid;
           objp[1].Value = userid;
           return ExecuteTable("SPGetSystemdetails", objp);
            

        }
        public string GetLikeEmpName(string strDivision, string strBranchName, string empname)
        {
            int divisionid = 0;
            int branchid = 0;
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
            return ExecuteReader("SPLikeEmpnameBranch", objp);
           
        }

        public void InsSoftwareDetail(int userid , string softwarename , string srkey)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@userid",SqlDbType.Int,4),
                                                        new SqlParameter("@name",SqlDbType.VarChar,25),
                                                        new SqlParameter("@srkey",SqlDbType.VarChar,100)};
            objp[0].Value = userid;
            objp[1].Value = softwarename;
            objp[2].Value = srkey;
            ExecuteQuery("SPInsSoftwareDetails", objp);
        }

        public DataTable GetSoftwareDetails(int userid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@userid",SqlDbType.Int,4)};

            objp[0].Value = userid;
            return ExecuteTable("SPGetSoftwareDetails", objp);
        }

        public void DelSoftwareDetail(int userid , int sfid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@userid",SqlDbType.Int,4),
                                                      new SqlParameter("@sfid",SqlDbType.Int,4)};
            objp[0].Value = userid;
            objp[1].Value = sfid;
            ExecuteQuery("SPDelSoftwareDetails", objp);
        }

        public void UpdSoftwareDetail(int userid, string softwarename, string srkey, int sfid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@userid",SqlDbType.Int,4),
                                                        new SqlParameter("@name",SqlDbType.VarChar,25),
                                                        new SqlParameter("@srkey",SqlDbType.VarChar,100),
                                                        new SqlParameter("@sfid",SqlDbType.Int,4)};
            objp[0].Value = userid;
            objp[1].Value = softwarename;
            objp[2].Value = srkey;
            objp[3].Value = sfid;
            ExecuteQuery("SPUpdSoftwareDetails", objp);
        }

    }
}
