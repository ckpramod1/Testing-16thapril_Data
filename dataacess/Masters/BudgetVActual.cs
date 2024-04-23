using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class BudgetVActual:DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public BudgetVActual()
        {
            Conn = new SqlConnection(DBCS);
        }

        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        public void InsBudgetDetail(int branchid, int bmonth, int byear, int fecvb, double fecrb, double felvb, double felrb, int fefvb, double fefrb, int femvb, double femrb, int febvb, double febrb, int ficvb, double ficrb, double filvb, double filrb, int fifvb, double fifrb, int fimvb, double fimrb, int fibvb, double fibrb, double aewb, double aerb, double aiwb, double airb, double chsevb, double chserb, double chsivb, double chsirb, double chaevb, double chaerb, double chaivb, double chairb)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@bmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@byear",SqlDbType.Int),
                                                        new SqlParameter("@fecvb",SqlDbType.Int),
                                                        new SqlParameter("@fecrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@felvb",SqlDbType.Real, 4),
                                                        new SqlParameter("@felrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fefvb",SqlDbType.Int),
                                                        new SqlParameter("@fefrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@femvb",SqlDbType.Int),
                                                        new SqlParameter("@femrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@febvb",SqlDbType.Int),
                                                        new SqlParameter("@febrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@ficvb",SqlDbType.Int),
                                                        new SqlParameter("@ficrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@filvb",SqlDbType.Real, 4),
                                                        new SqlParameter("@filrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fifvb",SqlDbType.Int),
                                                        new SqlParameter("@fifrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fimvb",SqlDbType.Int),
                                                        new SqlParameter("@fimrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fibvb",SqlDbType.Int),
                                                        new SqlParameter("@fibrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@aewb",SqlDbType.Real, 4),
                                                        new SqlParameter("@aerb",SqlDbType.Money, 8),
                                                        new SqlParameter("@aiwb",SqlDbType.Real, 4),
                                                        new SqlParameter("@airb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chsevb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chserb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chsivb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chsirb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chaevb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chaerb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chaivb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chairb",SqlDbType.Money, 8) };
            objp[0].Value = branchid;
            objp[1].Value = bmonth;
            objp[2].Value = byear;
            objp[3].Value = fecvb;
            objp[4].Value = fecrb;
            objp[5].Value = felvb;
            objp[6].Value = felrb;
            objp[7].Value = fefvb;
            objp[8].Value = fefrb;
            objp[9].Value = femvb;
            objp[10].Value = femrb;
            objp[11].Value = febvb;
            objp[12].Value = febrb;
            objp[13].Value = ficvb;
            objp[14].Value = ficrb;
            objp[15].Value = filvb;
            objp[16].Value = filrb;
            objp[17].Value = fifvb;
            objp[18].Value = fifrb;
            objp[19].Value = fimvb;
            objp[20].Value = fimrb;
            objp[21].Value = fibvb;
            objp[22].Value = fibrb;
            objp[23].Value = aewb;
            objp[24].Value = aerb;
            objp[25].Value = aiwb;
            objp[26].Value = airb;
            objp[27].Value = chsevb;
            objp[28].Value = chserb;
            objp[29].Value = chsivb;
            objp[30].Value = chsirb;
            objp[31].Value = chaevb;
            objp[32].Value = chaerb;
            objp[33].Value = chaivb;
            objp[34].Value = chairb;
            ExecuteQuery("SPInsBudget", objp);
        }

        public DataTable SelBudgetVActual(int branchid, int bmonth, int byear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@bmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@byear",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = bmonth;
            objp[2].Value = byear;
            return ExecuteTable("SPSelBudgetVActual", objp);
        }

        public void UpdBudgetDetail(int branchid, int bmonth, int byear, int fecvb, double fecrb, double felvb, double felrb, int fefvb, double fefrb, int femvb, double femrb, int febvb, double febrb, int ficvb, double ficrb, double filvb, double filrb, int fifvb, double fifrb, int fimvb, double fimrb, int fibvb, double fibrb, double aewb, double aerb, double aiwb, double airb, double chsevb, double chserb, double chsivb, double chsirb, double chaevb, double chaerb, double chaivb, double chairb)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@bmonth",SqlDbType.Int),
                                                        new SqlParameter("@byear",SqlDbType.Int),
                                                        new SqlParameter("@fecvb",SqlDbType.Int),
                                                        new SqlParameter("@fecrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@felvb",SqlDbType.Real, 4),
                                                        new SqlParameter("@felrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fefvb",SqlDbType.Int),
                                                        new SqlParameter("@fefrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@femvb",SqlDbType.Int),
                                                        new SqlParameter("@femrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@febvb",SqlDbType.Int),
                                                        new SqlParameter("@febrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@ficvb",SqlDbType.Int),
                                                        new SqlParameter("@ficrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@filvb",SqlDbType.Real, 4),
                                                        new SqlParameter("@filrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fifvb",SqlDbType.Int),
                                                        new SqlParameter("@fifrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fimvb",SqlDbType.Int),
                                                        new SqlParameter("@fimrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@fibvb",SqlDbType.Int),
                                                        new SqlParameter("@fibrb",SqlDbType.Money, 8),
                                                        new SqlParameter("@aewb",SqlDbType.Real, 4),
                                                        new SqlParameter("@aerb",SqlDbType.Money, 8),
                                                        new SqlParameter("@aiwb",SqlDbType.Real, 4),
                                                        new SqlParameter("@airb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chsevb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chserb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chsivb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chsirb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chaevb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chaerb",SqlDbType.Money, 8),
                                                        new SqlParameter("@chaivb",SqlDbType.Real, 4),
                                                        new SqlParameter("@chairb",SqlDbType.Money, 8) };
            objp[0].Value = branchid;
            objp[1].Value = bmonth;
            objp[2].Value = byear;
            objp[3].Value = fecvb;
            objp[4].Value = fecrb;
            objp[5].Value = felvb;
            objp[6].Value = felrb;
            objp[7].Value = fefvb;
            objp[8].Value = fefrb;
            objp[9].Value = femvb;
            objp[10].Value = femrb;
            objp[11].Value = febvb;
            objp[12].Value = febrb;
            objp[13].Value = ficvb;
            objp[14].Value = ficrb;
            objp[15].Value = filvb;
            objp[16].Value = filrb;
            objp[17].Value = fifvb;
            objp[18].Value = fifrb;
            objp[19].Value = fimvb;
            objp[20].Value = fimrb;
            objp[21].Value = fibvb;
            objp[22].Value = fibrb;
            objp[23].Value = aewb;
            objp[24].Value = aerb;
            objp[25].Value = aiwb;
            objp[26].Value = airb;
            objp[27].Value = chsevb;
            objp[28].Value = chserb;
            objp[29].Value = chsivb;
            objp[30].Value = chsirb;
            objp[31].Value = chaevb;
            objp[32].Value = chaerb;
            objp[33].Value = chaivb;
            objp[34].Value = chairb;
            ExecuteQuery("SPUpdBudget", objp);
        }
        
        public DataTable SelBudgetVActualFromTo(int branchid, int fmonth, int fyear, int tmonth, int tyear,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fyear",SqlDbType.Int),
                                                        new SqlParameter("@tmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@tyear",SqlDbType.Int),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt, 1)};
            objp[0].Value = branchid;
            objp[1].Value = fmonth;
            objp[2].Value = fyear;
            objp[3].Value = tmonth;
            objp[4].Value = tyear;
            objp[5].Value = divisionid;
            return ExecuteTable("SPSelBudgetVActualrpt", objp);
        }

        public DataTable SelPerformanceActivity4Volume(int branchid, int fmonth, int fyear, int tmonth, int tyear, int divisionid,string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fyear",SqlDbType.Int),
                                                        new SqlParameter("@tmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@tyear",SqlDbType.Int),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt, 1),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = branchid;
            objp[1].Value = fmonth;
            objp[2].Value = fyear;
            objp[3].Value = tmonth;
            objp[4].Value = tyear;
            objp[5].Value = divisionid;
            objp[6].Value = trantype;
            if (trantype == "FE" || trantype == "FI")
            {
                return ExecuteTable("SPPerformanceActivity4Volume", objp);
            }
            else
            {
                return ExecuteTable("SPPerformanceActivity4VolumeAir", objp);
            }
        }
        public DataTable SelPerformanceActivity4Revenue(int branchid, int fmonth, int fyear, int tmonth, int tyear, int divisionid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fyear",SqlDbType.Int),
                                                        new SqlParameter("@tmonth",SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@tyear",SqlDbType.Int),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt, 1),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = branchid;
            objp[1].Value = fmonth;
            objp[2].Value = fyear;
            objp[3].Value = tmonth;
            objp[4].Value = tyear;
            objp[5].Value = divisionid;
            objp[6].Value = trantype;
            if (trantype == "FE" || trantype == "FI")
            {
                return ExecuteTable("SPPerformanceActivity4Revenue", objp);
            }
            else
            {
                return ExecuteTable("SPPerformanceActivity4RevenueAir", objp);
            }
        }
        public DataTable SelBudvAct4Volume(int DivisionID, int fmonth, int fyear, int tmonth, int tyear,string Ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid",SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fmonth",SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fyear",SqlDbType.Int),
                                                       new SqlParameter("@tmonth",SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@tyear",SqlDbType.Int), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,1) };
            objp[0].Value = DivisionID;
            objp[1].Value = fmonth;
            objp[2].Value = fyear;
            objp[3].Value = tmonth;
            objp[4].Value = tyear;
            objp[5].Value = Ftype;
            return ExecuteTable("SPSelBudvAct4Volume", objp);
        }
        public DataTable SelBudVact4yearcomp(int divisionid, int fyear, int tyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@divisionid",SqlDbType.TinyInt, 1),
                                                       
                                                        new SqlParameter("@fyear",SqlDbType.Int),
                                                      
                                                        new SqlParameter("@tyear",SqlDbType.Int)
                                                        };
            objp[0].Value = divisionid;
            objp[1].Value = fyear;
            objp[2].Value = tyear;

            return ExecuteTable("SPSelBudVact4yearcomp", objp);
        }
        public DataTable SelBudVact4yearcompBranch(int branchid, int fyear, int tyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                       
                                                        new SqlParameter("@fyear",SqlDbType.Int),
                                                      
                                                        new SqlParameter("@tyear",SqlDbType.Int)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = fyear;
            objp[2].Value = tyear;

            return ExecuteTable("SPSelBudVact4yearcompbranch", objp);
        }
    }
}
