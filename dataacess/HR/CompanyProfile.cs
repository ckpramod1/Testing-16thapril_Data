using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace DataAccess.HR
{
    public class CompanyProfile : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
       
        public CompanyProfile()
        {
            Conn = new SqlConnection(DBCS);
        }


        //RATHA
        //Company Profile
        public void InsCompanyProfile(string strProfile, string strMission, string strAchievemission, string strPhilosophy, string strBeliefs, string strAttregister, string strDresscode, string strSalarystru, string strLeave, string strProbation)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@profile",SqlDbType.VarChar,2000),
                            new SqlParameter("@mission",SqlDbType.VarChar,2000),
                            new SqlParameter("@achievemission",SqlDbType.VarChar,2000),
                            new SqlParameter("@philosophy",SqlDbType.VarChar,2000),
                            new SqlParameter("@beliefs",SqlDbType.VarChar,2000),
                            new SqlParameter("@attregister",SqlDbType.VarChar,2000),
                            new SqlParameter("@dresscode",SqlDbType.VarChar,2000),
                            new SqlParameter("@salarystru",SqlDbType.VarChar,2000),
                            new SqlParameter("@leave",SqlDbType.VarChar,2000),
                            new SqlParameter("@probation",SqlDbType.VarChar,2000) 
                        };
            objp[0].Value = strProfile;
            objp[1].Value = strMission;
            objp[2].Value = strAchievemission;
            objp[3].Value = strPhilosophy;
            objp[4].Value = strBeliefs;
            objp[5].Value = strAttregister;
            objp[6].Value = strDresscode;
            objp[7].Value = strSalarystru;
            objp[8].Value = strLeave;
            objp[9].Value = strProbation;
            ExecuteQuery("SPInsInductionHandbook", objp);
        }

        public void UpdCompanyProfile(string strProfile, string strMission, string strAchievemission, string strPhilosophy, string strBeliefs, string strAttregister, string strDresscode, string strSalarystru, string strLeave, string strProbation)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@profile",SqlDbType.VarChar,2000),
                            new SqlParameter("@mission",SqlDbType.VarChar,2000),
                            new SqlParameter("@achievemission",SqlDbType.VarChar,2000),
                            new SqlParameter("@philosophy",SqlDbType.VarChar,2000),
                            new SqlParameter("@beliefs",SqlDbType.VarChar,2000),
                            new SqlParameter("@attregister",SqlDbType.VarChar,2000),
                            new SqlParameter("@dresscode",SqlDbType.VarChar,2000),
                            new SqlParameter("@salarystru",SqlDbType.VarChar,2000),
                            new SqlParameter("@leave",SqlDbType.VarChar,2000),
                            new SqlParameter("@probation",SqlDbType.VarChar,2000) 
                        };
            objp[0].Value = strProfile;
            objp[1].Value = strMission;
            objp[2].Value = strAchievemission;
            objp[3].Value = strPhilosophy;
            objp[4].Value = strBeliefs;
            objp[5].Value = strAttregister;
            objp[6].Value = strDresscode;
            objp[7].Value = strSalarystru;
            objp[8].Value = strLeave;
            objp[9].Value = strProbation;
            ExecuteQuery("SPUpdInductionHandbook", objp);
        }

        //for Employee Benefits
        public void InsEmpBenefits(string strLta, string strMedical, string strLunch, string strEntertainment, string strDriverWages, string strEpf, string strEsi, string strGratuity, string strBonus, string strTravel, string strvmr,string inscont)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@lta",SqlDbType.VarChar,2000),
                            new SqlParameter("@medical",SqlDbType.VarChar,2000),
                            new SqlParameter("@lunch",SqlDbType.VarChar,2000),
                            new SqlParameter("@entertainment",SqlDbType.VarChar,2000),
                            new SqlParameter("@driverwages",SqlDbType.VarChar,2000),
                            new SqlParameter("@epf",SqlDbType.VarChar,2000),
                            new SqlParameter("@esi",SqlDbType.VarChar,2000),
                            new SqlParameter("@gratuity",SqlDbType.VarChar,2000),
                            new SqlParameter("@bonus",SqlDbType.VarChar,2000),
                            new SqlParameter("@travel",SqlDbType.VarChar,2000),
                            new SqlParameter("@vmr",SqlDbType.VarChar,2000), new SqlParameter("@inscont",SqlDbType.VarChar,2000)
                        };
            objp[0].Value = strLta;
            objp[1].Value = strMedical;
            objp[2].Value = strLunch;
            objp[3].Value = strEntertainment;
            objp[4].Value = strDriverWages;
            objp[5].Value = strEpf;
            objp[6].Value = strEsi;
            objp[7].Value = strGratuity;
            objp[8].Value = strBonus;
            objp[9].Value = strTravel;
            objp[10].Value = strvmr;
            objp[11].Value = inscont;
            ExecuteQuery("SPInsEmployeeBenefits", objp);
        }

        public void UpdEmpBenefits(string strLta, string strMedical, string strLunch, string strEntertainment, string strDriverWages, string strEpf, string strEsi, string strGratuity, string strBonus, string strTravel, string strvmr, string inscont)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@lta",SqlDbType.VarChar,2000),
                            new SqlParameter("@medical",SqlDbType.VarChar,2000),
                            new SqlParameter("@lunch",SqlDbType.VarChar,2000),
                            new SqlParameter("@entertainment",SqlDbType.VarChar,2000),
                            new SqlParameter("@driverwages",SqlDbType.VarChar,2000),
                            new SqlParameter("@epf",SqlDbType.VarChar,2000),
                            new SqlParameter("@esi",SqlDbType.VarChar,2000),
                            new SqlParameter("@gratuity",SqlDbType.VarChar,2000),
                            new SqlParameter("@bonus",SqlDbType.VarChar,2000),
                            new SqlParameter("@travel",SqlDbType.VarChar,2000) ,
                           new SqlParameter("@vmr",SqlDbType.VarChar,2000),
                           new SqlParameter("@inscont",SqlDbType.VarChar,2000)
                        };
            objp[0].Value = strLta;
            objp[1].Value = strMedical;
            objp[2].Value = strLunch;
            objp[3].Value = strEntertainment;
            objp[4].Value = strDriverWages;
            objp[5].Value = strEpf;
            objp[6].Value = strEsi;
            objp[7].Value = strGratuity;
            objp[8].Value = strBonus;
            objp[9].Value = strTravel;
            objp[10].Value = strvmr;
            objp[11].Value = inscont;
            ExecuteQuery("SPUpdEmployeeBenefits", objp);
        }



        //for WelFare Measures
        public void InsWelfareMeasures(string strGpic, string strElencash, string strEmpWed, string strEmpreferral,string strEmpgrplifeinc)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@gpic",SqlDbType.VarChar,2000),
                            new SqlParameter("@elencash",SqlDbType.VarChar,2000),
                            new SqlParameter("@empwed",SqlDbType.VarChar,2000),
                            new SqlParameter("@empreferral",SqlDbType.VarChar,2000),
                           new SqlParameter("@empgrplifeinc",SqlDbType.VarChar,2000)
                        };
            objp[0].Value = strGpic;
            objp[1].Value = strElencash;
            objp[2].Value = strEmpWed;
            objp[3].Value = strEmpreferral;
            objp[4].Value = strEmpgrplifeinc;
            ExecuteQuery("SPInsWelfareMeasures", objp);
        }

        public void UpdWelfareMeasures(string strGpic, string strElencash, string strEmpWed, string strEmpreferral, string strEmpgrplifeinc)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@gpic",SqlDbType.VarChar,2000),
                            new SqlParameter("@elencash",SqlDbType.VarChar,2000),
                            new SqlParameter("@empwed",SqlDbType.VarChar,2000),
                            new SqlParameter("@empreferral",SqlDbType.VarChar,2000),
                             new SqlParameter("@empgrplifeinc",SqlDbType.VarChar,2000)
                        };
            objp[0].Value = strGpic;
            objp[1].Value = strElencash;
            objp[2].Value = strEmpWed;
            objp[3].Value = strEmpreferral;
            objp[4].Value = strEmpgrplifeinc;
            ExecuteQuery("SPUpdWelfareMeasures", objp);
        }


        //Income Tax
        public void InsupdIncometax(string strincometax, string strprobationapp, string strannualapp, string strsugpolicy, string strincentivepolicy, string strgrievancepolicy,string type)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@incometax",SqlDbType.VarChar,2000),
                             new SqlParameter("@probationapp",SqlDbType.VarChar,2000),
                                new SqlParameter("@annualapp",SqlDbType.VarChar,2000),
                                   new SqlParameter("@sugpolicy",SqlDbType.VarChar,2000), 
                                        new SqlParameter("@incentivepolicy",SqlDbType.VarChar,2000),
                new SqlParameter("@grievancepolicy",SqlDbType.VarChar,2000),
                 new SqlParameter("@save",SqlDbType.VarChar,10)

                           
                        };
            objp[0].Value = strincometax;
            objp[1].Value = strprobationapp;
            objp[2].Value = strannualapp;
            objp[3].Value = strsugpolicy;
            objp[4].Value = strincentivepolicy;
            objp[5].Value = strgrievancepolicy;
            objp[6].Value = type;
            ExecuteQuery("sp_inserthrappraisalpolicy", objp);
        }
       



        public DataTable GetCompanyProfile(short option)
        {

            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                        new SqlParameter("@option",SqlDbType.TinyInt,1)
                                                    };
            objp[0].Value = option;
            return ExecuteTable("SPSelCompanyProfile", objp);
        }



        //Get Work Details for User Profile
        public DataTable GetWorkDetails(int month, int year, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@month", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int, 4),
                new SqlParameter("@preparedby", SqlDbType.Int, 4)
                                                     };
            objp[0].Value = month;
            objp[1].Value = year;
            objp[2].Value = empid;
            return ExecuteTable("SPGetWorkDetails", objp);
        }
        public DataTable GetWorkIndividualDetails(int month, int year, int empid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@month", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int, 4),
                new SqlParameter("@preparedby", SqlDbType.Int, 4),
                new SqlParameter("@type", SqlDbType.VarChar,25)
                                                     };
            objp[0].Value = month;
            objp[1].Value = year;
            objp[2].Value = empid;
            objp[3].Value = type;
            return ExecuteTable("SPGetWorkIndividualDtls", objp);
        }
    }
}
