using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Payroll
{
    public class LWF : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public LWF()
        {
            Conn = new SqlConnection(DBCS);
        }

        //public void SveLWF(int bid, double slapfrm, double slapto, double empamt,double empramt, System.Windows.Forms.ListView lv, DateTime validfrom, DateTime validto)
        //{


        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
        //                                               new SqlParameter("@slapfrm", SqlDbType.Money),
        //       new SqlParameter("@slapto", SqlDbType.Money),
        //       new SqlParameter("@empamt", SqlDbType.Money),
        //        new SqlParameter("@empramt", SqlDbType.Money),
        //       new SqlParameter("@Tid",SqlDbType.TinyInt),
        //        new SqlParameter("@validfrom",SqlDbType.DateTime,8),
        //        new SqlParameter("@validto",SqlDbType.DateTime,8)  
        //   };
        //    objp[0].Value = bid;
        //    objp[1].Value = slapfrm;
        //    objp[2].Value = slapto;
        //    objp[3].Value = empamt;
        //    objp[4].Value = empramt;
        //    objp[5].Direction = ParameterDirection.Output;
        //    objp[6].Value = validfrom;
        //    objp[7].Value = validto;
        //    int tmp_Tid = ExecuteQuery("SPInsLWF", objp, "@Tid");

        //    for (int i = 1; i <= lv.Items.Count; i++)
        //    {
        //        if (lv.Items[i - 1].Checked == true)
        //        {
        //            objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
        //                                               new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
        //           };
        //            objp[0].Value = tmp_Tid;
        //            objp[1].Value = i;
        //            ExecuteQuery("SPInsLWFDet", objp);

        //        }

        //    }
        //}

        //public void UpdateLWF(int tid, int bid, double slabfrm, double slabto, double empamt, double empramt, System.Windows.Forms.ListView lv, DateTime validfrom, DateTime validto)
        //{


        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
        //                                               new SqlParameter("@slabfrm", SqlDbType.Money),
        //       new SqlParameter("@slabto", SqlDbType.Money),
        //       new SqlParameter("@empamt", SqlDbType.Money),
        //        new SqlParameter("@empramt", SqlDbType.Money),
        //       new SqlParameter("@Tid",SqlDbType.TinyInt),
        //        new SqlParameter("@validfrom",SqlDbType.DateTime,8),
        //        new SqlParameter("@validto",SqlDbType.DateTime,8)  
        //   };
        //    objp[0].Value = bid;
        //    objp[1].Value = slabfrm;
        //    objp[2].Value = slabto;
        //    objp[3].Value = empamt;
        //    objp[4].Value = empramt;
        //    objp[5].Value = tid;
        //    objp[6].Value = validfrom;
        //    objp[7].Value = validto;
        //    int tmp_Tid = ExecuteQuery("SPUpdateLWF", objp, "@Tid");

        //    for (int i = 1; i <= lv.Items.Count; i++)
        //    {
        //        if (lv.Items[i - 1].Checked == true)
        //        {
        //            objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
        //                                               new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
        //           };
        //            objp[0].Value = tid;
        //            objp[1].Value = i;
        //            ExecuteQuery("SPInsLWFDet", objp);

        //        }

        //    }
        //}

        public void SveLWF(int bid, double slapfrm, double slapto, double empamt, double empramt, System.Windows.Forms.ListView lv, DateTime validfrom, DateTime validto, int minemp)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@empamt", SqlDbType.Money),
                new SqlParameter("@empramt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                new SqlParameter("@minemp",SqlDbType.Int,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = empamt;
            objp[4].Value = empramt;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = validfrom;
            objp[7].Value = validto;
            objp[8].Value = minemp;
            int tmp_Tid = ExecuteQuery("SPInsLWF", objp, "@Tid");

            for (int i = 1; i <= lv.Items.Count; i++)
            {
                if (lv.Items[i - 1].Checked == true)
                {
                    objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                    objp[0].Value = tmp_Tid;
                    objp[1].Value = i;
                    ExecuteQuery("SPInsLWFDet", objp);

                }

            }
        }

        public void UpdateLWF(int tid, int bid, double slabfrm, double slabto, double empamt, double empramt, System.Windows.Forms.ListView lv, DateTime validfrom, DateTime validto, int minemp)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@empamt", SqlDbType.Money),
                new SqlParameter("@empramt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                new SqlParameter("@minemp", SqlDbType.Int,4)
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = empamt;
            objp[4].Value = empramt;
            objp[5].Value = tid;
            objp[6].Value = validfrom;
            objp[7].Value = validto;
            objp[8].Value = minemp;
            int tmp_Tid = ExecuteQuery("SPUpdateLWF", objp, "@Tid");

            for (int i = 1; i <= lv.Items.Count; i++)
            {
                if (lv.Items[i - 1].Checked == true)
                {
                    objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                    objp[0].Value = tid;
                    objp[1].Value = i;
                    ExecuteQuery("SPInsLWFDet", objp);

                }

            }
        }

        public DataTable SelLWF(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = bid;
            return ExecuteTable("SPSelLWF", objp);
        }

        public DataTable SelLWFDet(int Tid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = Tid;
            return ExecuteTable("SPSelLWFDet", objp);
        }
        public void DelLWF(int tid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tid", SqlDbType.Int) };
            objp[0].Value = tid;
            ExecuteQuery("SPDelLWF", objp);
        }



        public DataTable GetGrade(string grade)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@grade",SqlDbType.VarChar,4)
                        };
            objp[0].Value = grade;
            return ExecuteTable("SPGetGrade", objp);
        }

        public int Inslwfgrade(int branch, string grade, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@branch",SqlDbType.Int,4),
            new SqlParameter("@grade",SqlDbType.VarChar,4),
            new SqlParameter("@portid",SqlDbType.Int,4),
            new SqlParameter("@lgid",SqlDbType.Int,2)
            };

            objp[0].Value = branch;
            objp[1].Value = grade;
            objp[2].Value = portid;
            objp[3].Direction = ParameterDirection.Output;

            return ExecuteQuery("SPInsGradeLWF", objp, "@lgid");
        }


        public void Updlwfgrade(int branch, string grade, int portid, int lgid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@grade",SqlDbType.VarChar,4),
            new SqlParameter("@lgid",SqlDbType.Int,2)
            };

            //objp[0].Value = branch;
            objp[0].Value = grade;
            //objp[2].Value = portid;
            objp[1].Value = lgid;

            ExecuteQuery("SPUpdLwfgrade", objp);
        }

        public DataTable Getlwfgrade(int branch, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@portid",SqlDbType.Int,4)
            };

            objp[0].Value = branch;
            objp[1].Value = portid;
            return ExecuteTable("SPGetLWFgradeDtls", objp);
        }

        public void Dellwfgrade(int lgid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@lgid",SqlDbType.Int,2)
            };

            objp[0].Value = lgid;
            ExecuteQuery("SPDelLWFgrade", objp);
        }
        //public DataTable Getemdtl(string empcode)
        //{


        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar,10)
                                                       
              
        //   };
        //    objp[0].Value = empcode;
        //    return ExecuteTable("SPEmpdtls", objp);
        //}
        public DataTable Getemdtl(string empcode, int year)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar,10),
                                                       new SqlParameter("@year",SqlDbType.Int,4)
          };
            objp[0].Value = empcode;
            objp[1].Value = year;
            return ExecuteTable("SPEmpdtls", objp);
        }

        public void InsLwfDtls(string empcode, int month, int year, int noofdeduct, string remarks)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar,8), 
                new SqlParameter("@month", SqlDbType.Int,4), 
                                                       new SqlParameter("@year", SqlDbType.Int,4),              
                                                      new SqlParameter("@noofdeduct",SqlDbType.Int,4) ,
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,50)
           };
            objp[0].Value = empcode;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = noofdeduct;
            objp[4].Value = remarks;
            ExecuteQuery("SPLwfIns", objp);
        }

        public DataTable GetLwfDtls(string empcode, int month, int year)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar,8),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                       new SqlParameter("@year", SqlDbType.Int,4)
                                                       
              
           };
            objp[0].Value = empcode;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetLwfDls", objp);
        }

        public void UpdLwfDls(int lateattnid, int month, int year, int noofdeduct, string remarks)
        //public void UpdLwfDls(int month, int year, int noofdeduct, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@lateattn",SqlDbType.Int,4),
        new SqlParameter("@month",SqlDbType.Int,4),
                                                       new SqlParameter("@year", SqlDbType.Int,4),
                                                       new SqlParameter("@noofdeduct",SqlDbType.Int,4) ,
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,50)
        
               
            };
            objp[0].Value = lateattnid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = noofdeduct;
            objp[4].Value = remarks;
            ExecuteQuery("SPUpdLwfdls", objp);
        }
        public void DelDtls(int lateattn)
        {
            SqlParameter[] objp = new SqlParameter[]{
       
        new SqlParameter("@lateattn", SqlDbType.Int,4)
        
        
               
            };
            // objp[0].Value = month;
            objp[0].Value = lateattn;

            ExecuteQuery("SPDelLwfDls", objp);
        }
        public DataTable GetOneEmpDtls(string empcode)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar,8)
                                                       
              
           };
            objp[0].Value = empcode;

            return ExecuteTable("SPSelLwfDls", objp);
        }


        /*Dinesh*/

        public void SveLWFWeb(int bid, double slapfrm, double slapto, double empamt, double empramt, string[] lv, DateTime validfrom, DateTime validto, int minemp)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slapfrm", SqlDbType.Money),
               new SqlParameter("@slapto", SqlDbType.Money),
               new SqlParameter("@empamt", SqlDbType.Money),
                new SqlParameter("@empramt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                new SqlParameter("@minemp",SqlDbType.Int,4) 
           };
            objp[0].Value = bid;
            objp[1].Value = slapfrm;
            objp[2].Value = slapto;
            objp[3].Value = empamt;
            objp[4].Value = empramt;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = validfrom;
            objp[7].Value = validto;
            objp[8].Value = minemp;
            int tmp_Tid = ExecuteQuery("SPInsLWF", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {

                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tmp_Tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsLWFDet", objp);

            }
        }

        public void UpdateLWFWeb(int tid, int bid, double slabfrm, double slabto, double empamt, double empramt, string[] lv, DateTime validfrom, DateTime validto, int minemp)
        {


            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int,4), 
                                                       new SqlParameter("@slabfrm", SqlDbType.Money),
               new SqlParameter("@slabto", SqlDbType.Money),
               new SqlParameter("@empamt", SqlDbType.Money),
                new SqlParameter("@empramt", SqlDbType.Money),
               new SqlParameter("@Tid",SqlDbType.TinyInt),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8)  ,
                new SqlParameter("@minemp", SqlDbType.Int,4)
           };
            objp[0].Value = bid;
            objp[1].Value = slabfrm;
            objp[2].Value = slabto;
            objp[3].Value = empamt;
            objp[4].Value = empramt;
            objp[5].Value = tid;
            objp[6].Value = validfrom;
            objp[7].Value = validto;
            objp[8].Value = minemp;
            int tmp_Tid = ExecuteQuery("SPUpdateLWF", objp, "@Tid");

            for (int i = 0; i <= lv.Length - 1; i++)
            {

                objp = new SqlParameter[] { new SqlParameter("@Tid", SqlDbType.Int,4), 
                                                       new SqlParameter("@MonthNo", SqlDbType.TinyInt),                       
                   };
                objp[0].Value = tid;
                objp[1].Value = lv[i];
                ExecuteQuery("SPInsLWFDet", objp);

            }
        }

        //Arun

        public DataTable SpGetApproveNewDetails(int Empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Empid", SqlDbType.Int)
 };
            objp[0].Value = Empid;

            return ExecuteTable("SpGetReturnApproval", objp);
        }




        public void GetLeaveApplication(int empid, string Location, DateTime filldate, string destination, string grade, string department, float leaverequired, string leavetype, DateTime fromdate, DateTime todate, string purpose, string leaveaddress, string phone, int preperedby, string sessions)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Empid", SqlDbType.Int), 
                                    new SqlParameter("@Location", SqlDbType.VarChar,100),
                                    new SqlParameter("@FillDate", SqlDbType.DateTime),
                                      new SqlParameter("@designation", SqlDbType.VarChar,30),
                                        new SqlParameter("@grade", SqlDbType.VarChar,10),
                                          new SqlParameter("@department", SqlDbType.VarChar,50),
                                            new SqlParameter("@leaverequired", SqlDbType.Money),
                                              new SqlParameter("@Leavetype", SqlDbType.VarChar,10),
                                                new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                 new SqlParameter("@todate", SqlDbType.DateTime),
                                                 new SqlParameter("@purpose", SqlDbType.VarChar,100),
                                                 new SqlParameter("@leaveAddress", SqlDbType.VarChar,200),
                                                 new SqlParameter("@phone", SqlDbType.BigInt),
                                                 new SqlParameter("@preperedby", SqlDbType.Int),
                                                  new SqlParameter("@sessions", SqlDbType.VarChar,15)
            };
            objp[0].Value = empid;
            objp[1].Value = Location;
            objp[2].Value = filldate;
            objp[3].Value = destination;
            objp[4].Value = grade;
            objp[5].Value = department;
            objp[6].Value = leaverequired;
            objp[7].Value = leavetype;
            objp[8].Value = fromdate;
            objp[9].Value = todate;
            objp[10].Value = purpose;
            objp[11].Value = leaveaddress;
            objp[12].Value = phone;
            objp[13].Value = preperedby;
            objp[14].Value = sessions;
            ExecuteQuery("SPGetInsLeaveApplicationForm", objp);
        }


        public DataTable ApproveLeaveDetailsNew(int Empid, int approved, DateTime approvedon, char status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Empid", SqlDbType.Int),
             new SqlParameter("@ApprovedBy", SqlDbType.Int),
                                    new SqlParameter("@Approvedon", SqlDbType.DateTime),
                                      new SqlParameter("@Approvalstatus", SqlDbType.Char),

             };
            objp[0].Value = Empid;
            objp[1].Value = approved;
            objp[2].Value = approvedon;
            objp[3].Value = status;
            return ExecuteTable("SpGetApproveLeaveApplicationsNew", objp);

        }




        public DataTable UpdateAppDetails(int Empid, DateTime filldate, int preperedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Empid", SqlDbType.Int),
                
                                    new SqlParameter("@FillDate", SqlDbType.DateTime),
                                     new SqlParameter("@preparedby", SqlDbType.Int),
             };
            objp[0].Value = Empid;
            objp[1].Value = filldate;
            objp[2].Value = preperedby;
            return ExecuteTable("SpGetAppOnStatus", objp);
        }
        //public DataTable GetKpiConfirmationDetailsNew()
        //{

        //    return ExecuteTable("SPGetDetails4KpiConfirmation");
        //}


        public DataTable GetKpiConfirmationDetailsNew(int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@year", SqlDbType.Int)                
                                   
             };
            objp[0].Value = year;
            return ExecuteTable("SPGetDetails4KpiConfirmation", objp);
        }
    }
}
