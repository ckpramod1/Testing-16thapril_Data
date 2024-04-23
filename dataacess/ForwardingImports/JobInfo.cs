using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Masters;

namespace DataAccess.ForwardingImports
{
    public class JobInfo:DBObject
    {
        MasterCustomer CustObj = new MasterCustomer();
        MasterPort PortObj = new MasterPort();
        MasterVessel VesselObj = new MasterVessel();
        MasterPackages PkgObj = new MasterPackages();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public JobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }

        //Insert Job Informations.
        //public int InsertJobInfo(int jobtype, string vesselname, string voyage, int mloid, int agentid, string eta, string etb, int polid, int podid, string mblno, DateTime dtembl, string CVslcode, string CLinecode, string CAgent, string CMaster, string CNation, string CArrport, string CLastport, string CPort1, string CPort2, string CGrt, string CNrt, string CVsltype, string CTotal, string Imno, DateTime jobdate, int cfsid, string cfscode, DateTime imdate, string callsign, int intBranchID, int PreparedBy, string bondno, string mmtdetails, string remarks, int intDivisionID, DateTime docrecdon)
        //{

        //    int vesselid = VesselObj.GetVesselid(vesselname);
        //    int arrportid = CArrport != "" ? PortObj.GetNPortid(CArrport) : 0;
        //    int lastportid = CLastport != "" ? PortObj.GetNPortid(CLastport) : 0;
        //    int port1id = CPort1 != "" ? PortObj.GetNPortid(CPort1) : 0;
        //    int port2id = CPort2 != "" ? PortObj.GetNPortid(CPort2) : 0;
        //    int ctotal = CTotal != "" ? int.Parse(CTotal) : 0;

        //    SqlParameter[] objp = new SqlParameter[]{  
        //                                                new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
        //                                                new SqlParameter("@vesselid",SqlDbType.Int),
        //                                                new SqlParameter("@voyage",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@mlo",SqlDbType.Int,4),
        //                                                new SqlParameter("@agent",SqlDbType.Int,4),
        //                                                new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@pol",SqlDbType.Int),
        //                                                new SqlParameter("@pod",SqlDbType.Int),
        //                                                new SqlParameter("@mblno",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@mbldate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@cvslcode",SqlDbType.VarChar,7),
        //                                                new SqlParameter("@clinecode",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@cagent",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@cmaster",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@cnation",SqlDbType.VarChar,20),
        //                                                new SqlParameter("@carrport",SqlDbType.Int),
        //                                                new SqlParameter("@clastport",SqlDbType.Int),
        //                                                new SqlParameter("@cp1port",SqlDbType.Int),
        //                                                new SqlParameter("@cp2port",SqlDbType.Int),
        //                                                new SqlParameter("@cgrt",SqlDbType.VarChar,12),
        //                                                new SqlParameter("@cnrt",SqlDbType.VarChar,6),
        //                                                new SqlParameter("@cvsltype",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@ctotal",SqlDbType.Int,4),
        //                                                new SqlParameter("@imno",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@cfsid",SqlDbType.Int,4),
        //                                                new SqlParameter("@cfscode",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@imdate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@callsign",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@preparedby",SqlDbType.Int),
        //                                                new SqlParameter("@bondno",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@mmtdetails",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@remarks",SqlDbType.VarChar,250),
        //                                                new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                                new SqlParameter("@cid", SqlDbType.TinyInt),
        //                                                new SqlParameter("@jobno",SqlDbType.Int,4),

        //                                                new SqlParameter("@docrecdon",SqlDbType.SmallDateTime )

        //                                           };
        //    objp[0].Value = jobtype;
        //    objp[1].Value = vesselid;
        //    objp[2].Value = voyage;
        //    objp[3].Value = mloid;
        //    objp[4].Value = agentid;
        //    objp[5].Value = DateTime.Parse(eta);
        //    objp[6].Value = DateTime.Parse(etb);
        //    objp[7].Value = polid;
        //    objp[8].Value = podid;
        //    objp[9].Value = mblno;
        //    objp[10].Value = dtembl;
        //    objp[11].Value = CVslcode;
        //    objp[12].Value = CLinecode;
        //    objp[13].Value = CAgent;
        //    objp[14].Value = CMaster;
        //    objp[15].Value = CNation;
        //    objp[16].Value = arrportid;
        //    objp[17].Value = lastportid;
        //    objp[18].Value = port1id;
        //    objp[19].Value = port2id;
        //    objp[20].Value = CGrt;
        //    objp[21].Value = CNrt;
        //    objp[22].Value = CVsltype;
        //    objp[23].Value = ctotal;
        //    objp[24].Value = Imno;
        //    objp[25].Value = jobdate;
        //    objp[26].Value = cfsid;
        //    objp[27].Value = cfscode;
        //    objp[28].Value = imdate;
        //    objp[29].Value = callsign;
        //    objp[30].Value = PreparedBy;
        //    objp[31].Value = bondno;
        //    objp[32].Value = mmtdetails;
        //    objp[33].Value = remarks;
        //    objp[34].Value = intBranchID;
        //    objp[35].Value = intDivisionID;
        //    objp[36].Direction = ParameterDirection.Output;
        //    objp[37].Value = docrecdon;
        //    return ExecuteQuery("SPInsFIJob", objp, "@jobno");
        //    //ExecuteQuery("SPInsFIJob", objp);
        //    //return GetJobno(mblno, intBranchID,intDivisionID);
        //}



        public int InsertJobInfo(int jobtype, string vesselname, string voyage, int mloid, int agentid, string eta, string etb, int polid,
          int podid, string mblno, DateTime dtembl, string CVslcode, string CLinecode, string CAgent, string CMaster, string CNation,
          string CArrport, string CLastport, string CPort1, string CPort2, string CGrt, string CNrt, string CVsltype, string CTotal,
          string Imno, DateTime jobdate, int cfsid, string cfscode, DateTime imdate, string callsign, int intBranchID, int PreparedBy,
          string bondno, string mmtdetails, string remarks, int intDivisionID, DateTime docrecdon, string obl, DateTime obldate)
        {

            int vesselid = VesselObj.GetVesselid(vesselname);
            int arrportid = CArrport != "" ? PortObj.GetNPortid(CArrport) : 0;
            int lastportid = CLastport != "" ? PortObj.GetNPortid(CLastport) : 0;
            int port1id = CPort1 != "" ? PortObj.GetNPortid(CPort1) : 0;
            int port2id = CPort2 != "" ? PortObj.GetNPortid(CPort2) : 0;
            int ctotal = CTotal != "" ? int.Parse(CTotal) : 0;

            SqlParameter[] objp = new SqlParameter[]{  
                                                        new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@agent",SqlDbType.Int,4),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@mbldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cvslcode",SqlDbType.VarChar,7),
                                                        new SqlParameter("@clinecode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@cagent",SqlDbType.VarChar,10),
                                                        new SqlParameter("@cmaster",SqlDbType.VarChar,30),
                                                        new SqlParameter("@cnation",SqlDbType.VarChar,20),
                                                        new SqlParameter("@carrport",SqlDbType.Int),
                                                        new SqlParameter("@clastport",SqlDbType.Int),
                                                        new SqlParameter("@cp1port",SqlDbType.Int),
                                                        new SqlParameter("@cp2port",SqlDbType.Int),
                                                        new SqlParameter("@cgrt",SqlDbType.VarChar,12),
                                                        new SqlParameter("@cnrt",SqlDbType.VarChar,6),
                                                        new SqlParameter("@cvsltype",SqlDbType.VarChar,5),
                                                        new SqlParameter("@ctotal",SqlDbType.Int,4),
                                                        new SqlParameter("@imno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cfsid",SqlDbType.Int,4),
                                                        new SqlParameter("@cfscode",SqlDbType.VarChar,10),
                                                        new SqlParameter("@imdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@callsign",SqlDbType.VarChar,15),
                                                        new SqlParameter("@preparedby",SqlDbType.Int),
                                                        new SqlParameter("@bondno",SqlDbType.VarChar,25),
                                                        new SqlParameter("@mmtdetails",SqlDbType.VarChar,25),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),

                                                        new SqlParameter("@docrecdon",SqlDbType.SmallDateTime ),
                                                        new SqlParameter("@obl", SqlDbType.VarChar,500 ),
                                                        new SqlParameter("@obldate", SqlDbType.SmallDateTime )
                                                        

                                                   };
            objp[0].Value = jobtype;
            objp[1].Value = vesselid;
            objp[2].Value = voyage;
            objp[3].Value = mloid;
            objp[4].Value = agentid;
            objp[5].Value = DateTime.Parse(eta);
            objp[6].Value = DateTime.Parse(etb);
            objp[7].Value = polid;
            objp[8].Value = podid;
            objp[9].Value = mblno;
            objp[10].Value = dtembl;
            objp[11].Value = CVslcode;
            objp[12].Value = CLinecode;
            objp[13].Value = CAgent;
            objp[14].Value = CMaster;
            objp[15].Value = CNation;
            objp[16].Value = arrportid;
            objp[17].Value = lastportid;
            objp[18].Value = port1id;
            objp[19].Value = port2id;
            objp[20].Value = CGrt;
            objp[21].Value = CNrt;
            objp[22].Value = CVsltype;
            objp[23].Value = ctotal;
            objp[24].Value = Imno;
            objp[25].Value = jobdate;
            objp[26].Value = cfsid;
            objp[27].Value = cfscode;
            objp[28].Value = imdate;
            objp[29].Value = callsign;
            objp[30].Value = PreparedBy;
            objp[31].Value = bondno;
            objp[32].Value = mmtdetails;
            objp[33].Value = remarks;
            objp[34].Value = intBranchID;
            objp[35].Value = intDivisionID;
            objp[36].Direction = ParameterDirection.Output;
            objp[37].Value = docrecdon;
            objp[38].Value = obl;
            objp[39].Value = obldate;

            // return ExecuteQuery("SPInsFIJob", objp, "@jobno");

            return ExecuteQuery("SPInsFIJobnew", objp, "@jobno");

            //ExecuteQuery("SPInsFIJob", objp);
            //return GetJobno(mblno, intBranchID,intDivisionID);
        }

        public DataTable GetGuruTypenew()
        {
            return ExecuteTable("SPGetGuruTypeNew");
        }

        //Update Job Informations.
        public void UpdateJobInfo(int jobno, int jobtype, string vesselname, string voyage, int mloid, int agentid, DateTime eta, DateTime etb, int polid, int podid,
            string mblno, DateTime dtembl, string CVslcode, string CLinecode, string CAgent, string CMaster, string CNation, string CArrport, string CLastport,
            string CPort1, string CPort2, string CGrt, string CNrt, string CVsltype, string CTotal, string Imno, DateTime jobdate, int cfsid, string cfscode,
            DateTime imdate, string callsign, int intBranchID, string bondno, string mmtdetails, string remarks, DateTime docrecdon, string obl, DateTime obldate)
        {
            int vesselid = VesselObj.GetVesselid(vesselname);
            int arrportid = CArrport != "" ? PortObj.GetNPortid(CArrport) : 0;
            int lastportid = CLastport != "" ? PortObj.GetNPortid(CLastport) : 0;
            int port1id = CPort1 != "" ? PortObj.GetNPortid(CPort1) : 0;
            int port2id = CPort2 != "" ? PortObj.GetNPortid(CPort2) : 0;
            int total = (CTotal.Equals("")) ? 0 : int.Parse(CTotal);

            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@agent",SqlDbType.Int,4),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@mbldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cvslcode",SqlDbType.VarChar,7),
                                                        new SqlParameter("@clinecode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@cagent",SqlDbType.VarChar,10),
                                                        new SqlParameter("@cmaster",SqlDbType.VarChar,30),
                                                        new SqlParameter("@cnation",SqlDbType.VarChar,20),
                                                        new SqlParameter("@carrport",SqlDbType.Int),
                                                        new SqlParameter("@clastport",SqlDbType.Int),
                                                        new SqlParameter("@cp1port",SqlDbType.Int),
                                                        new SqlParameter("@cp2port",SqlDbType.Int),
                                                        new SqlParameter("@cgrt",SqlDbType.VarChar,12),
                                                        new SqlParameter("@cnrt",SqlDbType.VarChar,6),
                                                        new SqlParameter("@cvsltype",SqlDbType.VarChar,5),
                                                        new SqlParameter("@ctotal",SqlDbType.Int,4),
                                                        new SqlParameter("@imno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@imdate",SqlDbType.SmallDateTime,4),
                                                        //new SqlParameter("@candate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cfsid",SqlDbType.Int,4),
                                                        new SqlParameter("@cfscode",SqlDbType.VarChar,10),
                                                        new SqlParameter("@callsign",SqlDbType.VarChar,15),
                                                        new SqlParameter("@bondno",SqlDbType.VarChar,25),
                                                        new SqlParameter("@mmtdetails",SqlDbType.VarChar,25),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),


                                                        new SqlParameter("@docrecdon", SqlDbType.SmallDateTime ),
                                                        new SqlParameter("@obl", SqlDbType.VarChar,500 ),
                                                        new SqlParameter("@obldate", SqlDbType.SmallDateTime )
                                                        //new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = jobtype;
            objp[2].Value = vesselid;
            objp[3].Value = voyage;
            objp[4].Value = mloid;
            objp[5].Value = agentid;
            objp[6].Value = eta;
            objp[7].Value = etb;
            objp[8].Value = polid;
            objp[9].Value = podid;
            objp[10].Value = mblno;
            objp[11].Value = dtembl;
            objp[12].Value = CVslcode;
            objp[13].Value = CLinecode;
            objp[14].Value = CAgent;
            objp[15].Value = CMaster;
            objp[16].Value = CNation;
            objp[17].Value = arrportid;
            objp[18].Value = lastportid;
            objp[19].Value = port1id;
            objp[20].Value = port2id;
            objp[21].Value = CGrt;
            objp[22].Value = CNrt;
            objp[23].Value = CVsltype;
            objp[24].Value = total;
            objp[25].Value = Imno;
            objp[26].Value = jobdate;
            objp[27].Value = imdate;
            //objp[28].Value = candate;
            objp[28].Value = cfsid;
            objp[29].Value = cfscode;
            objp[30].Value = callsign;
            objp[31].Value = bondno;
            objp[32].Value = mmtdetails;
            objp[33].Value = remarks;
            objp[34].Value = intBranchID;

            objp[35].Value = docrecdon;
            objp[36].Value = obl;
            objp[37].Value = obldate;
            //objp[35].Value = intDivisionID;
            //ExecuteQuery("SPUpdFIJob", objp);
            ExecuteQuery("SPUpdFIJobnew", objp);
        }




        public int GetJobno(string strMBLNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      {
                                                       new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = strMBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return int.Parse(ExecuteReader("SPFIJobno", objp));
        }



        ////Update Job Informations.
        //public void UpdateJobInfo(int jobno, int jobtype, string vesselname, string voyage, int mloid, int agentid, DateTime eta, DateTime etb, 
        //    int polid, int podid, string mblno, DateTime dtembl, string CVslcode, string CLinecode, string CAgent, string CMaster, string CNation, 
        //    string CArrport, string CLastport, string CPort1, string CPort2, string CGrt, string CNrt, string CVsltype, string CTotal, string Imno, 
        //    DateTime jobdate, int cfsid, string cfscode, DateTime imdate, string callsign, int intBranchID, string bondno, string mmtdetails, string remarks, DateTime docrecdon)
        //{
        //    int vesselid = VesselObj.GetVesselid(vesselname);
        //    int arrportid = CArrport != "" ? PortObj.GetNPortid(CArrport) : 0;
        //    int lastportid = CLastport != "" ? PortObj.GetNPortid(CLastport) : 0;
        //    int port1id = CPort1 != "" ? PortObj.GetNPortid(CPort1) : 0;
        //    int port2id = CPort2 != "" ? PortObj.GetNPortid(CPort2) : 0;
        //    int total = (CTotal.Equals("")) ? 0: int.Parse(CTotal);

        //    SqlParameter[] objp = new SqlParameter[]
        //                                            {
        //                                                new SqlParameter("@jobno",SqlDbType.Int),
        //                                                new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
        //                                                new SqlParameter("@vesselid",SqlDbType.Int),
        //                                                new SqlParameter("@voyage",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@mlo",SqlDbType.Int,4),
        //                                                new SqlParameter("@agent",SqlDbType.Int,4),
        //                                                new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@pol",SqlDbType.Int),
        //                                                new SqlParameter("@pod",SqlDbType.Int),
        //                                                new SqlParameter("@mblno",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@mbldate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@cvslcode",SqlDbType.VarChar,7),
        //                                                new SqlParameter("@clinecode",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@cagent",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@cmaster",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@cnation",SqlDbType.VarChar,20),
        //                                                new SqlParameter("@carrport",SqlDbType.Int),
        //                                                new SqlParameter("@clastport",SqlDbType.Int),
        //                                                new SqlParameter("@cp1port",SqlDbType.Int),
        //                                                new SqlParameter("@cp2port",SqlDbType.Int),
        //                                                new SqlParameter("@cgrt",SqlDbType.VarChar,12),
        //                                                new SqlParameter("@cnrt",SqlDbType.VarChar,6),
        //                                                new SqlParameter("@cvsltype",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@ctotal",SqlDbType.Int,4),
        //                                                new SqlParameter("@imno",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@imdate",SqlDbType.SmallDateTime,4),
        //                                                //new SqlParameter("@candate",SqlDbType.SmallDateTime,4),
        //                                                new SqlParameter("@cfsid",SqlDbType.Int,4),
        //                                                new SqlParameter("@cfscode",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@callsign",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@bondno",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@mmtdetails",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@remarks",SqlDbType.VarChar,250),
        //                                                new SqlParameter("@bid", SqlDbType.TinyInt),


        //                                                new SqlParameter("@docrecdon", SqlDbType.SmallDateTime )
        //                                                //new SqlParameter("@cid", SqlDbType.TinyInt)
        //                                            };
        //    objp[0].Value = jobno;
        //    objp[1].Value = jobtype;
        //    objp[2].Value = vesselid;
        //    objp[3].Value = voyage;
        //    objp[4].Value = mloid;
        //    objp[5].Value = agentid;
        //    objp[6].Value = eta;
        //    objp[7].Value = etb;
        //    objp[8].Value = polid;
        //    objp[9].Value = podid;
        //    objp[10].Value = mblno;
        //    objp[11].Value = dtembl;
        //    objp[12].Value = CVslcode;
        //    objp[13].Value = CLinecode;
        //    objp[14].Value = CAgent;
        //    objp[15].Value = CMaster;
        //    objp[16].Value = CNation;
        //    objp[17].Value = arrportid;
        //    objp[18].Value = lastportid;
        //    objp[19].Value = port1id;
        //    objp[20].Value = port2id;
        //    objp[21].Value = CGrt;
        //    objp[22].Value = CNrt;
        //    objp[23].Value = CVsltype;
        //    objp[24].Value = total;
        //    objp[25].Value = Imno;
        //    objp[26].Value = jobdate;
        //    objp[27].Value = imdate;
        //    //objp[28].Value = candate;
        //    objp[28].Value = cfsid;
        //    objp[29].Value = cfscode;
        //    objp[30].Value = callsign;
        //    objp[31].Value = bondno;
        //    objp[32].Value = mmtdetails;
        //    objp[33].Value = remarks;
        //    objp[34].Value = intBranchID;

        //    objp[35].Value = docrecdon;
        //    //objp[35].Value = intDivisionID;
        //    ExecuteQuery("SPUpdFIJob", objp);
        //}



        public void UpdateFIEventcoveringsenton(int jobno, DateTime coveringsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                        new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                        new SqlParameter("@coveringsenton",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = coveringsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventcaninvsenton(int jobno, DateTime caninvsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                   {
                                                        new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                        new SqlParameter("@caninvsenton",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };

            objp[0].Value = jobno;
            objp[1].Value = caninvsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventpa2accsenton(int jobno, DateTime pa2accsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@pa2accsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = pa2accsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventprealertsenton(int jobno, DateTime prealertsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@prealertsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = prealertsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventchqrecon(int jobno, DateTime chqrecon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@chqrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = chqrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventlinedorecon(int jobno, DateTime linedorecon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@linedorecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = linedorecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }

        public void UpdateFIEventdevanningrecon(int jobno, DateTime devanningrecon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@devanningrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = devanningrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }


        public void UpdateFIEventdestuffedon(int jobno, DateTime destuffedon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@destuffedon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = destuffedon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }
        public void UpdateFIEventrefundrecon(int jobno, DateTime refundrecon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@refundrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = refundrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }
        public void UpdateFIEventJobno(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      {
                                                         new SqlParameter("@jobno",SqlDbType.Int,30),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };

            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPUpdFIEvent", objp);
        }


        public void UpdateJobDeStuff(int jobno, DateTime destuffdate, string godownno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                   {
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@destuffdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@godownno",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };
            objp[0].Value = jobno;
            objp[1].Value = destuffdate;
            objp[2].Value = godownno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFIJobDeStuff", objp);
        }



        //Insert Container Details.   
        public void InsertContainerDtls(int jobno, string blno, string containerno, string size, string sealno, int total, double wgt, string isocode, char socflag,int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                        new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                        new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@total",SqlDbType.Int,4),
                                                        new SqlParameter("@weight",SqlDbType.Real,4),
                                                        new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                        new SqlParameter("@socflag",SqlDbType.VarChar,1),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = containerno;
            objp[3].Value = size;
            objp[4].Value = sealno;
            objp[5].Value = total;
            objp[6].Value = wgt;
            objp[7].Value = isocode;
            objp[8].Value = socflag;
            objp[9].Value = branchid;
            objp[10].Value = divisionid;
            ExecuteQuery("SPInsFIContainer", objp);
        }

   
        //Check Containertype Exist.
        public bool CheckContainertypeExist(string conttype)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                        new SqlParameter("@conttype", SqlDbType.VarChar, 4) 
                                                    };
            objp[0].Value = conttype;
            Dt = ExecuteTable("SPSelFIConttype", objp);
            if (Dt.Rows.Count == 0)
                return false;
            return true;
        }


        public DataTable ShowJobDetails(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                          new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFIJobDtls", objp);
        }
       


        public DataTable BindJobDetails(int jobno, string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     { 
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelContainerDetails", objp);
        }


        public void UpdateContainerDetails(int jobno, string containerno, string size, string sealno, int total, double wgt, string isocode, char socflag, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                        new SqlParameter("@size",SqlDbType.VarChar,6),
                                                        new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@total",SqlDbType.Int,4),
                                                        new SqlParameter("@wgt",SqlDbType.Real,4),
                                                        new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                        new SqlParameter("@socflag",SqlDbType.Char,1),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = size;
            objp[3].Value = sealno;
            objp[4].Value = total;
            objp[5].Value = wgt;
            objp[6].Value = isocode;
            objp[7].Value = socflag;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            ExecuteQuery("SPUpdFIContainerDetls", objp);
        }


        //Delete Container Details.( int,
        public void DeleteContainerdtls(int jobno, string containerno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {  
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFIContainerDetls", objp);
        }

        public void DeleteContDtls(int jobno, string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                  {
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                  };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFIContDtls", objp);
        }


        public DataTable BindSizeDDL()
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                     };
            return ExecuteTable("SPSelCOntainersize",objp);
        }


        //Get Job no.
        public int GetJobno(int jobtype, string vesselname, string voyage, string mlo, string agent, string pol, string pod, string eta, string etb, string mlolocation, string agentlocation, int intBranchID, int intDivisionID)
        {
            int jobno = 0;
            int vesselid = VesselObj.GetVesselid(vesselname);
            int polid = PortObj.GetNPortid(pol);
            int podid = PortObj.GetNPortid(pod);
            int mloid = CustObj.GetCustomerid(mlo, "Carrier / Airliner / MLO / Freight Forwarder", mlolocation);
            int agentid = CustObj.GetCustomerid(agent, "Agent / Principal", agentlocation);
            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                        new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@agent",SqlDbType.Int,4),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobtype;
            objp[1].Value = vesselid;
            objp[2].Value = voyage;
            objp[3].Value = mloid;
            objp[4].Value = agentid;
            objp[5].Value = eta;
            objp[6].Value = etb;
            objp[7].Value = polid;
            objp[8].Value = podid;
            objp[9].Value = intBranchID;
            objp[10].Value = intDivisionID;
            Dt = ExecuteTable("SPGetFIJobno", objp);
            for (int i = 0; i <= Dt.Rows.Count; i++)
            {
                jobno = int.Parse(Dt.Rows[0].ItemArray[0].ToString());
            }
            return jobno;
        }

        //Insert Job Count.
        public void InsertJobCont(int jobno, string blno, string containerno, string sizetype, string sealno, int total, double weight, string isocode, string socflag, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                        new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                        new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@total",SqlDbType.Int,4),
                                                        new SqlParameter("@weight",SqlDbType.Decimal,4),
                                                        new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                        new SqlParameter("@socflag",SqlDbType.VarChar,1),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = containerno;
            objp[3].Value = sizetype;
            objp[4].Value = sealno;
            objp[5].Value = total;
            objp[6].Value = weight;
            objp[7].Value = isocode;
            objp[8].Value = socflag;
            objp[9].Value = intBranchID;
            objp[10].Value = intDivisionID;
            ExecuteQuery("SPInsFIContainer", objp);
        }


        public DataTable BindJobgrid(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPSelOIJobinfogrd", objp);
        }




        //Methaods for windows application.
        public DataTable GetLikeMBLNo(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIMBLNo", objp);
        }

        public DataTable GetLikeMBLNoWOClosedJob(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIMBLNoWOClosedJob", objp);
        }

        public DataTable GetLikeOTHERMBLNo(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@mblno",SqlDbType.VarChar,12),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeOTHERFIMBLNo", objp);
        }


        public DataTable GetPA2AccDts(string datetype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@datetype",SqlDbType.VarChar,5),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPGetPA2AccDts", objp);
        }

        public DataTable GetEventTracking(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPSelEventTracking", objp);
        }


        public void UpdContDetails(int intJbNo, string strBLNo, string strContNo, string strSztype, string strSlNo, string strContNo1, int pkgs, double wt, string isocode, string socflag, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12), 
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@containerno1",SqlDbType.VarChar,12),
                                                         new SqlParameter("@pkg",SqlDbType.Int,4),
                                                         new SqlParameter("@wt",SqlDbType.Decimal,4),
                                                         new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                         new SqlParameter("@socflag",SqlDbType.Char,1),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = strContNo;
            objp[3].Value = strSztype;
            objp[4].Value = strSlNo;
            objp[5].Value = strContNo1;
            objp[6].Value = pkgs;
            objp[7].Value = wt;
            objp[8].Value = isocode;
            objp[9].Value = socflag;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdFIContDetails", objp);
        }


        public DataTable GetFIEventTracking(int intBranchID, string svalue, int fvalue, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@svalue",SqlDbType.VarChar,1),
                                                       new SqlParameter("@fvalue",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = svalue;
            objp[1].Value = fvalue;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFIEventTracking", objp);
        }


        public int CheckContainerNo(int jobno, string containerno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return int.Parse(ExecuteReader("SPCheckContainerAssign4BL", objp));
        }



        public DataTable SelFIEventTrackOper(int intBranchID, DateTime FromDate, DateTime ToDate, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intBranchID;
            objp[1].Value = FromDate;
            objp[2].Value = ToDate;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFIEventTrackOper", objp);
        }
        //salquery
        public DataTable GetSalesLikeMBLNo(string mblno, int salesid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter ("@salesid",SqlDbType.Int ,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = salesid;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPLikeSalesFIMBLNo", objp);
        }



        //FIEventTracking Operation
        public DataTable GetEventOperDetails(DateTime FromDate, DateTime ToDate, int intbid, int individ)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter ("@fromdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = FromDate;
            objp[1].Value = ToDate;
            objp[2].Value = intbid;
            objp[3].Value = individ;
            return ExecuteTable("SPGetFIEventOperation", objp);
        }

        //MANI
        public DataTable GetPathTypeDetailsOnly(int jobno, string trantype, string type, int intbid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter ("@jobno",SqlDbType.Int ,4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 4),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = intbid;
            return ExecuteTable("SPGetPathType", objp);
        }

        public DataTable GetGuruType(string type)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter ("@type",SqlDbType .VarChar ,4)
            };
            objp[0].Value = type;
            return ExecuteTable("SPGetGuruType", objp);
        }

        //Manoj
        //DataAccess.ForwardingImports.JobInfo

        public DataTable GetJobInfoforDestuff(int jobno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter ("@jobno",SqlDbType .Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetJobInfoForDestuff", objp);
        }

        public DataTable GetContforDestuff(int jobno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter ("@jobno",SqlDbType .Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetContFronJobDestuff", objp);
        }


        public void UpdFIContDtlsForDestuff(int jobno, int branchid, int divisionid, DateTime destuff, string containerno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4), 
                                                      new SqlParameter("@destuff",SqlDbType.SmallDateTime,10),
            new SqlParameter("@containerno",SqlDbType.VarChar,30)};

            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = destuff;
            objp[4].Value = containerno;
            ExecuteQuery("SPUpdDestuffinFIContainerDtls", objp);
        }
        public DataTable GetImpJobDetails(int bid, DateTime fdate, DateTime tdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@bid", SqlDbType.Int,4),
                                                     new SqlParameter("@fromdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@todate", SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@empid",SqlDbType.Int,4)
                                                  
                                                     };
            objp[0].Value = bid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = empid;
            return ExecuteTable("SPInsTempMIS", objp);
        }

        public DataTable GetVolumeRptForFI(DateTime fromdate, DateTime Todate, string func, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@fromdate", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@todate", SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@func",SqlDbType.VarChar,1)
                                                  
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = Todate;
            objp[3].Value = func;
            return ExecuteTable("SPGetJobTuesEtaandClosedWise", objp);
        }
        //RajaGuru
        public void updjobinfoprofit(string trantype, int jobno, int bid, string jobprofit, int carrierid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobno",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@jobprofit",SqlDbType.Char,1),
                                                     new SqlParameter("@carrierid",SqlDbType.Int)};
            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = bid;
            objp[3].Value = jobprofit;
            objp[4].Value = carrierid;
            ExecuteQuery("spupdjobinfoprofit", objp);
        }


         //Dinesh

        public DataTable GETfijobinforpt(int branchid, string jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 10),
             new SqlParameter("@jobno", SqlDbType.VarChar, 20)};
            objp[0].Value = branchid;
            objp[1].Value = jobno;
            return ExecuteTable("spfijobinforpt", objp);
        }

        //Dinesh

        public DataTable GetLikeMBLNoWOClosedJobnew(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIMBLNoWOClosedJobnew", objp);
        }
        //ForwardingImports.cs
        //Tally
        public DataTable ShowJobDetailsnew(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFIJobDtlsfornewtally", objp);
        }

        public DataTable GetLikechMBLNo(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikechMBLNo", objp);
        }


        public DataTable GetPA2AccDtsAEAI(string datetype, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@datetype",SqlDbType.VarChar,25),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                          new SqlParameter("@trantype",SqlDbType.VarChar,10),
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetPA2AccDtsAEAI", objp);
        }

        public void UpdateaeEventNom(int jobno, DateTime Nomrecon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@Nomrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = Nomrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventPickcon(int jobno, DateTime Pickupon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@Pickupon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = Pickupon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

        public void UpdateaeEventDocrecon(int jobno, DateTime docrecon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@docrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = docrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

        public void UpdateaeEventPrealon(int jobno, DateTime prealsenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@prealsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = prealsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventInvon(int jobno, DateTime invoicesenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@invoicesenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = invoicesenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventwaron(int jobno, DateTime waron, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@waron",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = waron;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventariaion(int jobno, DateTime ariaion, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@ariaion",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = ariaion;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

        public void UpdateaeEventdeliupdon(int jobno, DateTime deliupdon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@deliupdon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = deliupdon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

        public void UpdateaeEventOrion(int jobno, DateTime Originaldocsenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@Originaldocsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = Originaldocsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventflischon(int jobno, DateTime flischon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@flischon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = flischon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }


        public void UpdateaeEventbookon(int jobno, DateTime bookon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@bookon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bookon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

        public void UpdateaeEventdoissueon(int jobno, DateTime doissueon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@doissueon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = doissueon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdaeEvent", objp);
        }

         
        //Sindhuja    --> CH

        public DataTable GetPA2AccDtsCH(string datetype, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@datetype",SqlDbType.VarChar,25),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                          new SqlParameter("@trantype",SqlDbType.VarChar,10),
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetPA2AccDtsch", objp);
        }




        public void UpdatechEventCop(int jobno, DateTime CopyDoc, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@CopyDoc",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = CopyDoc;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventorig(int jobno, DateTime oridocrec, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@oridocrec",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = oridocrec;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventigm(int jobno, DateTime igmdate, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@igmdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = igmdate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventcarg(int jobno, DateTime cargodestuff, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("@cargodestuff",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargodestuff;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventboe(int jobno, DateTime boenodt, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("boenodt",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = boenodt;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);

        }
        public void UpdatechEventbond(int jobno, DateTime bondnodt, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("bondnodt",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bondnodt;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventduty(int jobno, DateTime dutypaid, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("dutypaid",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = dutypaid;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventbonded(int jobno, DateTime bondedat, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("bondedat",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bondedat;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }

        public void UpdatechEventcargo(int jobno, DateTime cargodelidate, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("cargodelidate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargodelidate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventtrans(int jobno, DateTime trandone, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("trandone",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = trandone;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventvend(int jobno, DateTime vendorinv, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("vendorinv",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = vendorinv;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventfin(int jobno, DateTime finalinv, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("finalinv",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = finalinv;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventoridoc(int jobno, DateTime oridocsendon, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("oridocsendon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = oridocsendon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventexbond(int jobno, DateTime exbondboefilling, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("exbondboefilling",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = exbondboefilling;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }
        public void UpdatechEventcardeli(int jobno, DateTime cargodeliver, int intBranchID, int intDivisionID, string trantype, string docno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("cargodeliver",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@docno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargodeliver;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = docno;
            ExecuteQuery("SPUpdchaEvent", objp);
        }








         //Sindhuja    --> FE
         
        public DataTable GetPA2AccDtsFE(string datetype, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@datetype",SqlDbType.VarChar,25),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                          new SqlParameter("@trantype",SqlDbType.VarChar,10),
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetPA2AccDtsFE", objp);
        }

        public void UpdateFEEventsstuff(int jobno, DateTime stuffsenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("stuffsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = stuffsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }


        public void UpdateFEEventspickup(int jobno, DateTime pickedupon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("pickedupon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = pickedupon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }


        public void UpdateFEEventscustdt(int jobno, DateTime customdate, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("customdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = customdate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventstssenton(int jobno, DateTime tssenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("tssenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = tssenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventsprealert(int jobno, DateTime prealertsenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("prealertsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = prealertsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventsrailout(int jobno, DateTime railoutdate, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("railoutdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = railoutdate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventscargorec(int jobno, DateTime cargoreceivedon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("cargoreceivedon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargoreceivedon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }
        public void UpdateFEEventsinspect(int jobno, DateTime inspectedon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("inspectedon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = inspectedon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventsbooking(int jobno, DateTime bookingdate, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("bookingdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bookingdate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }
        public void UpdateFEEventsbldate(int jobno, DateTime bldate, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("bldate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bldate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }

        public void UpdateFEEventslcsenton(int jobno, DateTime lcsenton,  int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
              {
                   new SqlParameter("@jobno",SqlDbType.Int, 1),
                   new SqlParameter("@lcsenton",SqlDbType.SmallDateTime,4),
                   new SqlParameter("@bid", SqlDbType.TinyInt),
                   new SqlParameter("@cid", SqlDbType.TinyInt),
                     new SqlParameter("@trantype", SqlDbType.VarChar,50),
                       new SqlParameter("@blno", SqlDbType.VarChar,50)
              };

            objp[0].Value = jobno;
            objp[1].Value = lcsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFEEvents", objp);
        }




        //sindhuja ---FI

        public DataTable GetPA2AccDtsFI(string datetype, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@datetype",SqlDbType.VarChar,25),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                          new SqlParameter("@trantype",SqlDbType.VarChar,10),
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetPA2AccDtsFI", objp);
        }

        public void UpdateFIEventsbookings(int jobno, DateTime bookingdate, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("bookingdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = bookingdate;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventsoriginon(int jobno, DateTime originon, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("originon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = originon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);

        }


        public void UpdateFIEventsdraftconfir(int jobno, DateTime draftconfir, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("draftconfir",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = draftconfir;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }
        public void UpdateFIEventsvesseldepar(int jobno, DateTime vesseldepar, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("vesseldepar",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = vesseldepar;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventsprealertsenton(int jobno, DateTime prealertsenton, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("prealertsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = prealertsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventstransarrive(int jobno, DateTime transarrive, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("transarrive",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = transarrive;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventstransdepart(int jobno, DateTime transdepart, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("transdepart",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = transdepart;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventsvesselarrivepod(int jobno, DateTime vesselarrivepod, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("vesselarrivepod",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = vesselarrivepod;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }
        public void UpdateFIEventsdesticfsarrival(int jobno, DateTime desticfsarrival, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("desticfsarrival",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = desticfsarrival;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }
        public void UpdateFIEventscargodestuff(int jobno, DateTime cargodestuff, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("cargodestuff",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargodestuff;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }
        public void UpdateFIEventsdeliorderstatus(int jobno, DateTime deliorderstatus, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("deliorderstatus",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = deliorderstatus;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventscargodeli(int jobno, DateTime cargodeli, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("cargodeli",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = cargodeli;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }

        public void UpdateFIEventsempcontreturn(int jobno, DateTime empcontreturn, int intBranchID, int intDivisionID, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 1),
                                                         new SqlParameter("empcontreturn",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50),
                                                             new SqlParameter("@blno", SqlDbType.VarChar,50)
                                                    };

            objp[0].Value = jobno;
            objp[1].Value = empcontreturn;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            ExecuteQuery("SPUpdFIEvents", objp);
        }




        public DataTable spgetevents(int bid, string blno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                        
                                                         new SqlParameter("@bid", SqlDbType.TinyInt), 
                                                            new SqlParameter("@blno", SqlDbType.VarChar,100),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,50)
                                                          
                                                    };

            objp[0].Value = bid;
            objp[1].Value = blno;
            objp[2].Value = trantype;

           return ExecuteTable("spevents", objp);
        }


        public DataTable GetLikeBLNo(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIBLNo", objp);
        }
        // yuvaraj 30-12-2022
        public DataTable amass_json(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter ("@jobno",SqlDbType .Int),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2)
            };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("sp_amass_json", objp);
        }
        public DataTable GetBL_Test(string blno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@blno",SqlDbType.VarChar,30),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = blno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetBL_Test", objp);
        }
        public void  UPDetdinjob(int jobno, int branchid, DateTime ETD)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter ("@jobno",SqlDbType .Int),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@etd",SqlDbType.DateTime)
            };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = ETD;
             ExecuteQuery("SPUPDetdinjob", objp);
        }


    }

}


       
    

