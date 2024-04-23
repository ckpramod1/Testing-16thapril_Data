using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace DataAccess
{
    public class CostingDetails : DBObject
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        //Variable Declaration.
        protected int count;
        protected DataTable tempDt;
        protected double amount;
        protected double income;
        protected double expense;
        protected double invoice;
        protected double oscn;
        protected double dn;
        protected double cn;
        protected double pa;
        protected double osdn;
        protected double osinv;
        protected double ospa;


        public int exprowcount = 0;

        //Methods.

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        //Methods.
       
        public CostingDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable CostingDetail(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnew1LV", objp);
        }

        public DataTable CostingDetail(int jobno, string trantype, int branchid, int vouyear)
        {
            DataTable NDt;
            NDt = InvoiceDetails(jobno, trantype, branchid, vouyear);
            tempDt = OSDNDetails(jobno, trantype, branchid, vouyear);

            //Append OSDN Details with InvoiceDetails.
            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();

                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[4].ToString();
                if (!tempDt.Rows[i].ItemArray[3].ToString().Equals("0"))
                    Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[2].ToString());
                Dr[4] = DateTime.Now.Year;
                Dr[5] = tempDt.Rows[i].ItemArray[3].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = DNDetails(jobno, trantype, branchid, vouyear);

            //Append OSDN Details with InvoiceDetails.
            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = OSPADetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            //Append New Row For TotalIncome.
            Dr = NDt.NewRow();
            Dr[2] = "Income Total";
            income = invoice + osdn + dn + ospa;
            Dr[3] = income;
            NDt.Rows.Add(Dr);

            //Append paymentAdvice Details.
            tempDt = PADetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            //Append OSCN Details.
            tempDt = OSCNDetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[4].ToString();
                if (!tempDt.Rows[i].ItemArray[3].ToString().Equals("0"))
                    Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[2].ToString());
                Dr[4] = DateTime.Now.Year;
                Dr[5] = tempDt.Rows[i].ItemArray[3].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = CNDetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = OSInvDetails(jobno, trantype, branchid, vouyear);

            //Append OSDN Details with InvoiceDetails.
            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            //Append New Row For TotalExpenses.
            Dr = NDt.NewRow();
            Dr[2] = "Expenses Total";
            expense = pa + oscn + cn + osinv;
            Dr[3] = expense;
            NDt.Rows.Add(Dr);

            //Append New Row For Profit/Loss.
            Dr = NDt.NewRow();
            amount = income - expense;
            if (amount > 0)
                Dr[2] = "Profit";
            else
                Dr[2] = "Loss";
            Dr[3] = amount;
            NDt.Rows.Add(Dr);

            return NDt;
        }

        public DataTable InvoiceDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingInv", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Invoice");

            invoice = TotalAmount(Ds.Tables["Invoice"]);
            //Add a new column VouType.
            Ds.Tables["Invoice"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["Invoice"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["Invoice"].Rows[i];
                Dr[5] = "Invoice";
            }

            return Ds.Tables["Invoice"];
        }


        public DataTable DNDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingDN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "DN");

            dn = TotalAmount(Ds.Tables["DN"]);
            //Add a new column VouType.
            Ds.Tables["DN"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["DN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["DN"].Rows[i];
                Dr[5] = "DN";
            }

            return Ds.Tables["DN"];
        }

        public DataTable OSInvDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingOSInv", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Agent DN");

            osinv = TotalAmount(Ds.Tables["Agent DN"]);
            //Add a new column VouType.
            Ds.Tables["Agent DN"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["Agent DN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["Agent DN"].Rows[i];
                Dr[5] = "Agent DN";
            }

            return Ds.Tables["Agent DN"];
        }
        public DataTable OSPADetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingOSPA", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Agent PA");

            ospa = TotalAmount(Ds.Tables["Agent PA"]);
            //Add a new column VouType.
            Ds.Tables["Agent PA"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["Agent PA"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["Agent PA"].Rows[i];
                Dr[5] = "Agent PA";
            }

            return Ds.Tables["Agent PA"];
        }

        public DataTable CNDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingCN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "CN");

            cn = TotalAmount(Ds.Tables["CN"]);
            //Add a new column VouType.
            Ds.Tables["CN"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["CN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["CN"].Rows[i];
                Dr[5] = "CN";
            }

            return Ds.Tables["CN"];
        }

        public DataTable PADetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingPA", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            

            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "PA");

            pa = TotalAmount(Ds.Tables["PA"]);

            //Add a new column VouType.
            Ds.Tables["PA"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["PA"].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["PA"].Rows[i];
                Dr[5] = "PA";
            }

            return Ds.Tables["PA"];
        }

        public DataTable OSDNDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingOSDN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            

            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "OSDN");

            osdn = TotalAmount(Ds.Tables["OSDN"]);

            //Add a new column VouType.
            Ds.Tables["OSDN"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["OSDN"].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["OSDN"].Rows[i];
                Dr[3] = "OSDN";
            }

            //Add a new column Customername.
            Ds.Tables["OSDN"].Columns.Add("customername", typeof(string));
            count = Ds.Tables["OSDN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["OSDN"].Rows[i];
                Dr[4] = "Agent";
            }

            return Ds.Tables["OSDN"];
        }

        public DataTable OSCNDetails(int jobno, string trantype, int branchid, int vouyear)
        {

            Cmd = new SqlCommand("SPCostingOSCN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "OSCN");

            oscn = TotalAmount(Ds.Tables["OSCN"]);
            //int R = Ds.Tables["OSCN"].Rows.Count;

            //Add a new column VouType.
            Ds.Tables["OSCN"].Columns.Add("voutype", typeof(string));
            count = Ds.Tables["OSCN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["OSCN"].Rows[i];
                Dr[3] = "OSCN";
            }

            //Add a new column Customername.
            Ds.Tables["OSCN"].Columns.Add("customername", typeof(string));
            count = Ds.Tables["OSCN"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Dr = Ds.Tables["OSCN"].Rows[i];
                Dr[4] = "Agent";
            }

            return Ds.Tables["OSCN"];
        }

        //Calculate the total amount.
        public double TotalAmount(DataTable dt1)
        {
            double amt = 0;
            if (dt1.TableName == "Invoice" || dt1.TableName == "PA" || dt1.TableName == "DN" || dt1.TableName == "CN" || dt1.TableName == "Agent DN" || dt1.TableName == "Agent PA")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i].ItemArray[3].ToString() != "")
                    {
                        amt += double.Parse(dt1.Rows[i].ItemArray[3].ToString());
                    }
                }
            }
            else if (dt1.TableName == "OSCN" || dt1.TableName == "OSDN")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i].ItemArray[2].ToString() != "")
                    {
                        amt += double.Parse(dt1.Rows[i].ItemArray[2].ToString());
                    }
                }
            }
            //dt1 = new DataTable();
            return amt;
        }

        public DataTable CostingDetailInCome(int jobno, string trantype, int branchid, int vouyear)
        {
            DataTable NDt;
            NDt = InvoiceDetails(jobno, trantype, branchid, vouyear);
            tempDt = OSDNDetails(jobno, trantype, branchid, vouyear);

            //Append OSDN Details with InvoiceDetails.
            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();

                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[4].ToString();
                if (!tempDt.Rows[i].ItemArray[3].ToString().Equals("0"))
                    Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[2].ToString());
                Dr[4] = DateTime.Now.Year;
                Dr[5] = tempDt.Rows[i].ItemArray[3].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = DNDetails(jobno, trantype, branchid, vouyear);

            //Append OSDN Details with InvoiceDetails.
            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }
            return NDt;
        }

        public DataTable CostingDetailExpense(int jobno, string trantype, int branchid, int vouyear)
        {
            DataTable NDt = new DataTable();

            NDt = PADetails(jobno, trantype, branchid, vouyear);

            //Append OSCN Details.
            tempDt = OSCNDetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[4].ToString();
                if (!tempDt.Rows[i].ItemArray[3].ToString().Equals("0"))
                    Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[2].ToString());
                Dr[4] = DateTime.Now.Year;
                Dr[5] = tempDt.Rows[i].ItemArray[3].ToString();
                NDt.Rows.Add(Dr);
            }

            tempDt = CNDetails(jobno, trantype, branchid, vouyear);

            for (int i = 0; i < tempDt.Rows.Count; i++)
            {
                Dr = NDt.NewRow();
                if (!tempDt.Rows[i].ItemArray[0].ToString().Equals("0"))
                    Dr[0] = int.Parse(tempDt.Rows[i].ItemArray[0].ToString());
                Dr[1] = tempDt.Rows[i].ItemArray[1].ToString();
                Dr[2] = tempDt.Rows[i].ItemArray[2].ToString();
                Dr[3] = double.Parse(tempDt.Rows[i].ItemArray[3].ToString());
                Dr[4] = tempDt.Rows[i].ItemArray[4].ToString();
                Dr[5] = tempDt.Rows[i].ItemArray[5].ToString();
                NDt.Rows.Add(Dr);
            }

            return NDt;
        }

        public void CreateCSVfile(DataTable dtable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            int icolcount = dtable.Columns.Count;
            for (int i = 0; i < icolcount; i++)
            {
                sw.Write(dtable.Columns[i]);
                if (i < icolcount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow drow in dtable.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }
                    if (i < icolcount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public void InsOutstandingInvDN(int branchid, int empid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = customerid;
            ExecuteQuery("SPOutstandingInvDN", objp);

        }

        public void InsOutstandingAgeing(int empid, int customerid, int branchid, int salb1, int salb2, int salb3, int salb4, int salb5)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@slab1",SqlDbType.Int,4),
                                                     new SqlParameter("@slab2",SqlDbType.Int,4),
                                                     new SqlParameter("@slab3",SqlDbType.Int,4),
                                                     new SqlParameter("@slab4",SqlDbType.Int,4),
                                                     new SqlParameter("@slab5",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = customerid;
            objp[2].Value = branchid;
            objp[3].Value = salb1;
            objp[4].Value = salb2;
            objp[5].Value = salb3;
            objp[6].Value = salb4;
            objp[7].Value = salb5;
            ExecuteQuery("SPInsTempOutstandingAgeing", objp);
        }

        //RAJA
        public void InsOutstandingAgeingraj(int empid, int customerid, int branchid, int salb1, int salb2, int salb3, int salb4, int salb5, int salb6, int salb7)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@slab1",SqlDbType.Int,4),
                                                     new SqlParameter("@slab2",SqlDbType.Int,4),
                                                     new SqlParameter("@slab3",SqlDbType.Int,4),
                                                     new SqlParameter("@slab4",SqlDbType.Int,4),
                                                     new SqlParameter("@slab5",SqlDbType.Int,4),
                                                     new SqlParameter("@slab6",SqlDbType.Int,4),
                                                     new SqlParameter("@slab7",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = customerid;
            objp[2].Value = branchid;
            objp[3].Value = salb1;
            objp[4].Value = salb2;
            objp[5].Value = salb3;
            objp[6].Value = salb4;
            objp[7].Value = salb5;
            objp[8].Value = salb6;
            objp[9].Value = salb7;
            ExecuteQuery("SPInsTempOutstandingAgeingraj", objp);
        }
        public void DelOutstandingAgeing(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelTempOutstandingAgeing", objp);
        }

        public DataTable GetOutstandingInvDN(int empid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = customerid;
            return ExecuteTable("SPSelOutstandingInvDN", objp);

        }

        public DataTable SelAllBranchRetention(int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4) };
            objp[0].Value = division;
            return ExecuteTable("SPSelAllBranchRetention", objp);

        }

        public DataTable GetRptVolumewise(string trantype,int branchid,DateTime from,DateTime to,string rpttype,string jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@jobtype", SqlDbType.VarChar, 1)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = from;
            objp[3].Value = to;
            objp[4].Value = rpttype;
            objp[5].Value = jobtype;
            return ExecuteTable("SPRptGetVolumewise", objp);

        }

        public void DelOutstandingInvDN(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelOutstandingInvDN", objp);

        }

        public DataTable SelAccOutStdForDivisionInvoice(int division, string Qtype, string custtype)
        {
           // double amt = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4),
                                                     new SqlParameter("@qtype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@custtype", SqlDbType.VarChar, 1)  };
            objp[0].Value = division;
            objp[1].Value = Qtype;
            objp[2].Value = custtype;
            Dt = ExecuteTable("SPSelAccOutStdForDivisionInvoice", objp);
            
            return Dt;
        }

        public DataTable SelAccOutStdForDivisionCustomer(int division, string Qtype,string custtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4),
                                                     new SqlParameter("@qtype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@custtype", SqlDbType.VarChar, 1) };
            objp[0].Value = division;
            objp[1].Value = Qtype;
            objp[2].Value = custtype;
            return ExecuteTable("SPSelAccOutStdForDivisionCustomer", objp);
        }
        public DataTable SelAccOutStdForDivisionExpense(int division, string Qtype, string custtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4),
                                                     new SqlParameter("@qtype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@custtype", SqlDbType.VarChar, 1)  };
            objp[0].Value = division;
            objp[1].Value = Qtype;
            objp[2].Value = custtype;
            return ExecuteTable("SPSelAccOutStdForDivisionExpense", objp);
        }

        public DataTable SelAccOutStdForDivisionCustomerExpense(int division, string Qtype, string custtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4),
                                                     new SqlParameter("@qtype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@custtype", SqlDbType.VarChar, 1) };
            objp[0].Value = division;
            objp[1].Value = Qtype;
            objp[2].Value = custtype;
            return ExecuteTable("SPSelAccOutStdForDivisionCustomerExpense", objp);
        }
        public DataSet SELTempMISFone(string trantype,int bid,DateTime fdate,DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid", SqlDbType.Int,4)
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;
            return ExecuteDataSet("SPSELTempMISFone", objp);
        }
        public DataSet SELTempMISFone4AC(int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid", SqlDbType.Int,4)
                                                     };
         
            objp[0].Value = bid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = empid;
            return ExecuteDataSet("SPSELTempMISFone4AC", objp);
        }
        public DataSet SELTempMISFTWO(string trantype, int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid", SqlDbType.Int,4)
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;
            return ExecuteDataSet("SPSELTempMISFTWO", objp);
        }
        public DataSet SELTempMISFTWOAC(int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid", SqlDbType.Int,4)
                                                     };

            objp[0].Value = bid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = empid;
            return ExecuteDataSet("SPSELTempMISFTWOAC", objp);
        }
        public DataTable SELMISJobDate(string trantype,int bid, DateTime fdate, DateTime tdate,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@empid",SqlDbType.Int,4)
                                                  
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;
            return ExecuteTable("SPSELMISJobDate", objp);
        }

        public DataTable SELMISJobDateandvessel(string trantype, int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4)
                                                  
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;

            return ExecuteTable("SPSELMISJobDateandvessel", objp);
        }
        public DataTable SELMISJobDateandvesselnotsailed(string trantype, int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4)
                                                  
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;

            return ExecuteTable("SPSELMISJobDateandvesselnotsailed", objp);
        }
        public DataTable SELMISJobDateandvesselsailed(string trantype, int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4)
                                                  
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;

            return ExecuteTable("SPSELMISJobDateandvesselsailed", objp);
        }
        //raj
        public DataSet CostingDetailInComeNew(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt, 1),
                                    };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteDataSet("SPGetIncomeExpense4CostSheet", objp);
        }
        //priya

        public DataTable BLCosting(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt, 1),
                                    };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetBL4mRPTCsting", objp);
        }

        public DataTable OutstandingAgeingCustwise(int division, string Qtype, string custtype)
        {
            // double amt = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int, 4),
                                                     new SqlParameter("@qtype", SqlDbType.VarChar, 1),
                                                     new SqlParameter("@custtype", SqlDbType.VarChar, 1)  };
            objp[0].Value = division;
            objp[1].Value = Qtype;
            objp[2].Value = custtype;
            return ExecuteTable("SPOutstandingAgeingCustwise", objp);

            // return Dt;
        }


        //MUTHU

        public DataTable getperformancecosting_Karthika(int empid, int divisionid, int branchid, string trantype, DateTime closeddate_from, DateTime closeddate_To)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                     new SqlParameter("@divid", SqlDbType.Int),
                                                     new SqlParameter("@bid", SqlDbType.Int),
                                                     new SqlParameter("@trantype", SqlDbType.VarChar, 4),
                                                     new SqlParameter("@closeddatefrom", SqlDbType.DateTime ),
                                                     new SqlParameter("@closeddateTo", SqlDbType.DateTime )
                                                     };
            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = closeddate_from;
            objp[5].Value = closeddate_To;
            //return ExecuteTable("sp_performancesales_Karthika", objp);
            return ExecuteTable("sp_performancesalesNew", objp);
        }


        public DataTable CostingDetailEDI(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnewEDI", objp);
        }


        //dinesh
        public DataTable Get_incomenotbookednew(int empid, string trantype, string status, string filter, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar),
                                                            new SqlParameter("@status", SqlDbType.VarChar),
                                                             new SqlParameter("@filter", SqlDbType.VarChar,100), new SqlParameter("@type", SqlDbType.VarChar)
            };
            objp[0].Value = empid;
            objp[1].Value = trantype;
            objp[2].Value = status;
            objp[3].Value = filter;
            objp[4].Value = type;
            //return ExecuteTable("sp_incomenotbookednewfilter", objp);
            return ExecuteTable("sp_incomenotbookednewfilternew", objp);

        }
        public DataTable Get_incomenotbooked(int empid, string trantype, string status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar),
                                                            new SqlParameter("@status", SqlDbType.VarChar)
            };
            objp[0].Value = empid;
            objp[1].Value = trantype;
            objp[2].Value = status;
            return ExecuteTable("sp_incomenotbookednew", objp);
        }


        // sindhu
        public DataTable GetBLcostingvouwise(int jobno, string blno, int branchid, string mblno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                  new SqlParameter("@blno",SqlDbType.VarChar,30),
                  new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                  new SqlParameter("@mblno",SqlDbType.VarChar,30),
                  new SqlParameter("@trantype",SqlDbType.VarChar,30),};

            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = branchid;
            objp[3].Value = mblno;
            objp[4].Value = trantype;
            return ExecuteTable("SPGetblcostingvouwise", objp);
        }

        //24nov2021
        public int Jobclosingdatechk(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return int.Parse(ExecuteReader("spjobchkcloseddate", objp));
        }
        public DataTable CostingDetailnew(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnewReversalnew", objp);
        }
        // add yuvaraj 30-12-2022


        public DataTable SP_PENDINGDO(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                    {
                                    new SqlParameter("@bid",SqlDbType.TinyInt, 1),
                                    };

            objp[0].Value = branchid;
            return ExecuteTable("SP_PENDINGDO", objp);
        }

        //new

        public DataTable CostingDetail_NEW(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnew_NEW", objp);
        }

        public DataTable CostingDetail_vouno(int jobno, string trantype, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@type",SqlDbType.VarChar,50)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = type;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnew_vouno", objp);
        }
        public DataTable Costingshipmentdetails(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPcostingshipmentdetails", objp);
        }
        public DataTable CostingDetail4shipingdtlsLV(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            //return ExecuteTable("SPCostingofJob", objp);
            return ExecuteTable("SPCostingOfJobnew1LV", objp);
        }
        public DataTable Get_incomenotbooked4fa23(int empid, string trantype, string status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar),
                                                            new SqlParameter("@status", SqlDbType.VarChar)
            };
            objp[0].Value = empid;
            objp[1].Value = trantype;
            objp[2].Value = status;
            return ExecuteTable("sp_incomenotbookedNew4FA2023", objp);
        }
    }
}

