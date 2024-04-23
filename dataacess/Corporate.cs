using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Corporate : DBObject
    {
        DataAccess.Masters.MasterVessel vslObj = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterCustomer custObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort prtObj = new DataAccess.Masters.MasterPort();

        int branchid, vesselid, shipperid, sgroupid, cneeid, cgroupid, agentid, agroupid, cargoid, porid, polid, podid, fdid;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Corporate()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsCorporate(string docno, DateTime docdate, string trantype, string branch, int jobno, string vessel, string voyage, string shipper, string shipperloc, string consignee, string cneeloc, string agent, string agentloc, string cargo, double volume, string por, string pol, string pod, string fd, string freight, string status,DateTime jobdate,int division,int cont20,int cont40)
        {
            branchid =int.Parse(branch);
                       
            cargoid = 0;

            vesselid = vslObj.GetVesselid(vessel);
            shipperid = custObj.GetCustomerid(shipper, "Shipper", shipperloc);
            cneeid = custObj.GetCustomerid(consignee, "Consignee", cneeloc);
            agentid = custObj.GetCustomerid(agent, "Agent / Principal", agentloc);

            sgroupid = GetGroupID(shipperid,division);
            cgroupid = GetGroupID(cneeid, division);
            agroupid = GetGroupID(agentid, division);

            porid = prtObj.GetNPortid(por);
            polid = prtObj.GetNPortid(pol);
            podid = prtObj.GetNPortid(pod);
            fdid = prtObj.GetNPortid(fd);



            Cmd = new SqlCommand("SPInsCorporate", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@docno", docno);
            Cmd.Parameters.AddWithValue("@docdate", docdate);
            Cmd.Parameters.AddWithValue("@trantype", trantype);
            Cmd.Parameters.AddWithValue("@branch", branchid);
            Cmd.Parameters.AddWithValue("@jobno", jobno);
            Cmd.Parameters.AddWithValue("@vesselid", vesselid);
            Cmd.Parameters.AddWithValue("@voyage", voyage);
            Cmd.Parameters.AddWithValue("@shipper", shipperid);
            //Cmd.Parameters.AddWithValue("@sgroup", sgroupid);
            Cmd.Parameters.AddWithValue("@consignee", cneeid);
            //Cmd.Parameters.AddWithValue("@cgroup", cgroupid);
            Cmd.Parameters.AddWithValue("@agent", agentid);
            //Cmd.Parameters.AddWithValue("@agroup", agroupid);
            Cmd.Parameters.AddWithValue("@cargotype", cargoid);
            Cmd.Parameters.AddWithValue("@volume", volume);
            Cmd.Parameters.AddWithValue("@por", porid);
            Cmd.Parameters.AddWithValue("@pol", polid);
            Cmd.Parameters.AddWithValue("@pod", podid);
            Cmd.Parameters.AddWithValue("@fd", fdid);
            Cmd.Parameters.AddWithValue("@freight", freight);
            Cmd.Parameters.AddWithValue("@status", status);
            Cmd.Parameters.AddWithValue("@jobdate", jobdate);
            Cmd.Parameters.AddWithValue("@division", division);
            Cmd.Parameters.AddWithValue("@cont20", cont20);
            Cmd.Parameters.AddWithValue("@cont40", cont40);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();

        }
        public void UpdCorporate(string docno, DateTime docdate, string trantype, string branch, int jobno, string vessel, string voyage, string shipper, string shipperloc, string consignee, string cneeloc, string agent, string agentloc, string cargo, double volume, string por, string pol, string pod, string fd, string freight, string status, DateTime jobdate, int cont20, int cont40,int division)
        {
            branchid =int.Parse(branch) ;
            cargoid = 0;

            vesselid = vslObj.GetVesselid(vessel);
            shipperid = custObj.GetCustomerid(shipper, "Shipper", shipperloc);
            cneeid = custObj.GetCustomerid(consignee, "Consignee", cneeloc);
            agentid = custObj.GetCustomerid(agent, "Agent / Principal", agentloc);

            sgroupid = GetGroupID(shipperid, division);
            cgroupid = GetGroupID(cneeid, division);
            agroupid = GetGroupID(agentid, division);

            porid = prtObj.GetNPortid(por);
            polid = prtObj.GetNPortid(pol);
            podid = prtObj.GetNPortid(pod);
            fdid = prtObj.GetNPortid(fd);



            Cmd = new SqlCommand("SPUpdCorporate", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@docno", docno);
            Cmd.Parameters.AddWithValue("@docdate", docdate);
            Cmd.Parameters.AddWithValue("@trantype", trantype);
            Cmd.Parameters.AddWithValue("@branch", branchid);
            Cmd.Parameters.AddWithValue("@jobno", jobno);
            Cmd.Parameters.AddWithValue("@vesselid", vesselid);
            Cmd.Parameters.AddWithValue("@voyage", voyage);
            Cmd.Parameters.AddWithValue("@shipper", shipperid);
            //Cmd.Parameters.AddWithValue("@sgroup", sgroupid);
            Cmd.Parameters.AddWithValue("@consignee", cneeid);
            //Cmd.Parameters.AddWithValue("@cgroup", cgroupid);
            Cmd.Parameters.AddWithValue("@agent", agentid);
            //Cmd.Parameters.AddWithValue("@agroup", agroupid);
            Cmd.Parameters.AddWithValue("@cargotype", cargoid);
            Cmd.Parameters.AddWithValue("@volume", volume);
            Cmd.Parameters.AddWithValue("@por", porid);
            Cmd.Parameters.AddWithValue("@pol", polid);
            Cmd.Parameters.AddWithValue("@pod", podid);
            Cmd.Parameters.AddWithValue("@fd", fdid);
            Cmd.Parameters.AddWithValue("@freight", freight);
            Cmd.Parameters.AddWithValue("@status", status);
            Cmd.Parameters.AddWithValue("@jobdate", jobdate);
            Cmd.Parameters.AddWithValue("@cont20", cont20);
            Cmd.Parameters.AddWithValue("@cont40", cont40);

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();

        }

        public int GetGroupID(int custid,int divisionid)
        {
            int groupid = 0;
            Cmd = new SqlCommand("SPSelGroupID", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@custid", custid);
            Cmd.Parameters.AddWithValue("@divisionid", divisionid);
            Ds = new DataSet();
            Adp = new SqlDataAdapter(Cmd);
            Adp.Fill(Ds, "Groupids");
            if (Ds.Tables[0].Rows.Count > 0)
            {
                string str = Ds.Tables[0].Rows[0][0].ToString();
                if (Ds.Tables[0].Rows[0][0].ToString() != null && Ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    groupid = int.Parse(Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return groupid;
        }

        
        public void UpdateShipmentStatus(string docno, string trantype, int jobno, int branchid, string status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@status",SqlDbType.VarChar,50)};
            objp[0].Value = docno;
            objp[1].Value = trantype;
            objp[2].Value = jobno;
            objp[3].Value = branchid;
            objp[4].Value = status;
            ExecuteQuery("SPUpdShipmentBLStatus", objp);
        }
        public void InsShipmentStatus(string shiprefno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = shiprefno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            ExecuteQuery("SPInsShipmentStatus", objp);
        }
        public void UpdShipmentStatus(string shiprefno, string trantype, int branchid, string status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@status",SqlDbType.VarChar,50)};
            objp[0].Value = shiprefno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = status;
            ExecuteQuery("SPUpdShipmentStatus", objp);
        }
        public DataTable SelInboundMISinBudgetVActualVolume(int branchid,int frommonth,int tomonth,int fyear,string type,string rpttype,int tyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.VarChar,5),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@frommonth", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@tomonth",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@fyear",SqlDbType.Int),
                                                    new SqlParameter("@rpttype",SqlDbType.VarChar,50),
                                                    new SqlParameter("@tyear",SqlDbType.Int)};
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = frommonth;
            objp[3].Value = tomonth;
            objp[4].Value = fyear;
            objp[5].Value = rpttype;
            objp[6].Value = tyear;
            Dt=ExecuteTable("SPSelInboundMISinBudgetVActualVolume", objp);
            return Dt;
        }
    }
}

