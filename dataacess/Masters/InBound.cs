using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
   public class InBound:DBObject
    {
       DataAccess.Masters.MasterPort PortObj = new MasterPort();
       DataAccess.Masters.MasterCharges chargeObj = new MasterCharges();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public InBound()
        {
            Conn = new SqlConnection(DBCS);
        }

        //public int InsertInboundHead(int agentid, int fromport, int toport, DateTime wef, DateTime validtill, char ctype, char cargo)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agentid", SqlDbType.Int, 4),
        //                                                new SqlParameter("@fromport", SqlDbType.Int),
        //                                                new SqlParameter("@toport", SqlDbType.Int),
        //                                                new SqlParameter("@wef", SqlDbType.DateTime, 8),
        //                                                new SqlParameter("@validtill", SqlDbType.DateTime, 8),
        //                                                new SqlParameter("@ctype", SqlDbType.Char, 1),
        //        new SqlParameter("@cargo", SqlDbType.Char, 1),
        //                                                new SqlParameter("@inboundid",SqlDbType.Int,4)};
        //    objp[0].Value = agentid;
        //    objp[1].Value = fromport;
        //    objp[2].Value = toport;
        //    objp[3].Value = wef;
        //    objp[4].Value = validtill;
        //    objp[5].Value = ctype;
        //    objp[6].Value = cargo;
        //    objp[7].Direction = ParameterDirection.Output;
        //    return ExecuteQuery("SPInsInboundHead", objp, "@inboundid");

        //}

        public int InsertInboundHead(int agentid, int fromport, int toport, DateTime wef, DateTime validtill, char ctype, char cargo, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agentid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromport", SqlDbType.Int),
                                                       new SqlParameter("@toport", SqlDbType.Int),
                                                       new SqlParameter("@wef", SqlDbType.DateTime, 8),
                                                       new SqlParameter("@validtill", SqlDbType.DateTime, 8),
                                                       new SqlParameter("@ctype", SqlDbType.Char, 1),
               new SqlParameter("@cargo", SqlDbType.Char, 1),
                new SqlParameter("@trantype", SqlDbType.VarChar),
                                                       new SqlParameter("@inboundid",SqlDbType.Int,4)};
           objp[0].Value = agentid;
           objp[1].Value = fromport;
           objp[2].Value = toport;
           objp[3].Value = wef;
           objp[4].Value = validtill;
           objp[5].Value = ctype;
           objp[6].Value = cargo;
           objp[7].Value = trantype;
           objp[8].Direction = ParameterDirection.Output;
           return ExecuteQuery("SPInsInboundHead", objp, "@inboundid");

       }

       //public void UpdateInboundHead(int inboundid, int agentid, int fromport, int toport, DateTime wef, DateTime validtill, char ctype, char cargo)
       //{
       //    //int fromportId = PortObj.GetNPortid(fromport);
       //    //int toportId = PortObj.GetNPortid(toport);
       //    SqlParameter[] objp = new SqlParameter[]
       //                                             {
       //                                               new SqlParameter("@inboundid",SqlDbType.Int,4),
       //                                               new SqlParameter("@agentid",SqlDbType.Int,4),
       //                                               new SqlParameter("@fromport",SqlDbType.Int),
       //                                               new SqlParameter("@toport",SqlDbType.Int),
       //                                               new SqlParameter("@wef",SqlDbType.SmallDateTime,4),
       //                                               new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
       //                                               new SqlParameter("@ctype", SqlDbType.Char, 1),
       //                                                   new SqlParameter("@cargo", SqlDbType.Char, 1)
       //                                             };


       //    objp[0].Value = inboundid;
       //    objp[1].Value = agentid;
       //    objp[2].Value = fromport;
       //    objp[3].Value = toport;
       //    objp[4].Value = wef;
       //    objp[5].Value = validtill;
       //    objp[6].Value = ctype;
       //    objp[7].Value = cargo;
       //    ExecuteQuery("SPUpdInboundHead", objp);
       //}

       public void UpdateInboundHead(int inboundid, int agentid, int fromport, int toport, DateTime wef, DateTime validtill, char ctype, char cargo, string trantype)
       {
           //int fromportId = PortObj.GetNPortid(fromport);
           //int toportId = PortObj.GetNPortid(toport);
           SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                      new SqlParameter("@inboundid",SqlDbType.Int,4),
                                                      new SqlParameter("@agentid",SqlDbType.Int,4),
                                                      new SqlParameter("@fromport",SqlDbType.Int),
                                                      new SqlParameter("@toport",SqlDbType.Int),
                                                      new SqlParameter("@wef",SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@ctype", SqlDbType.Char, 1),
                                                          new SqlParameter("@cargo", SqlDbType.Char, 1),
                                                              new SqlParameter("@trantype", SqlDbType.VarChar)
                                                    };


           objp[0].Value = inboundid;
           objp[1].Value = agentid;
           objp[2].Value = fromport;
           objp[3].Value = toport;
           objp[4].Value = wef;
           objp[5].Value = validtill;
           objp[6].Value = ctype;
           objp[7].Value = cargo;
           objp[8].Value = trantype;
           ExecuteQuery("SPUpdInboundHead", objp);
       }


       //public DataTable GetInboundHead(int agentid, int fromport, int toport, char ctype, char cargo)
       //{

       //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agentid", SqlDbType.Int, 4),
       //                                                 new SqlParameter("@fromport", SqlDbType.Int, 4),
       //                                                 new SqlParameter("@toport", SqlDbType.Int, 4),
       //     new SqlParameter("@ctype", SqlDbType.Char, 1),
       //     new SqlParameter("@cargo", SqlDbType.Char, 1)};
       //    objp[0].Value = agentid;
       //    objp[1].Value = fromport;
       //    objp[2].Value = toport;
       //    objp[3].Value = ctype;
       //    objp[4].Value = cargo;
       //    return ExecuteTable("SPGetInboundHead", objp);
       //}

       public DataTable GetInboundHead(int agentid, int fromport, int toport, char ctype, char cargo, string trantype)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agentid", SqlDbType.Int, 4),
                                                        new SqlParameter("@fromport", SqlDbType.Int, 4),
                                                        new SqlParameter("@toport", SqlDbType.Int, 4),
            new SqlParameter("@ctype", SqlDbType.Char, 1),
            new SqlParameter("@cargo", SqlDbType.Char, 1),
           new SqlParameter("@trantype", SqlDbType.VarChar),};
           objp[0].Value = agentid;
           objp[1].Value = fromport;
           objp[2].Value = toport;
           objp[3].Value = ctype;
           objp[4].Value = cargo;
           objp[5].Value = trantype;
           return ExecuteTable("SPGetInboundHead", objp);
       }
      
       public DataTable GetInboundDetails(int inboundid)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inboundid", SqlDbType.Int, 4) };
           objp[0].Value = inboundid;
           return ExecuteTable("SPGetInboundDetails", objp);
       }
              
       public void InsertInboundDetails(int inboundid, int chargeid, char chargetype, string cmbbase,double amount,string curr)
       {
           SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                      new SqlParameter("@inboundid",SqlDbType.Int,4),
                                                      new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                      new SqlParameter("@chargetype",SqlDbType.Char,1),
                                                      new SqlParameter("@base",SqlDbType.VarChar,10),
                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                      new SqlParameter("@curr",SqlDbType.VarChar,3)
                                                    };



           objp[0].Value = inboundid;
           objp[1].Value = chargeid;
           objp[2].Value = chargetype;
           objp[3].Value = cmbbase;
           objp[4].Value = amount;
           objp[5].Value = curr;
           ExecuteQuery("SPInsInboundDetails", objp);
       }
             
       public void UpdateInboundDetails(int inboundid, int chargeid, string customertype, string cmbbase, double amount, string curr)
       {
           SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                      new SqlParameter("@inboundid",SqlDbType.Int,4),
                                                      new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                      new SqlParameter("@chargetype",SqlDbType.Char,1),
                                                      new SqlParameter("@base",SqlDbType.VarChar,6),
                                                    new SqlParameter("@amount",SqlDbType.Money,8),
                                                      new SqlParameter("@curr",SqlDbType.VarChar,3)                                                     
                                                    };


           objp[0].Value = inboundid;
           objp[1].Value = chargeid;
           objp[2].Value = customertype;
           objp[3].Value = cmbbase;
           objp[4].Value = amount;
           objp[5].Value = curr;
           ExecuteQuery("SPUpdInboundDetails", objp);
       }
       public void DeleteInboundDetails(int inboundid, int chargeid, char chargetype)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@inboundid", SqlDbType.Int, 4),
                                                new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                new SqlParameter("@chargetype",SqlDbType.Char,1)
                                                     };
           objp[0].Value = inboundid;
           objp[1].Value = chargeid;
           objp[2].Value = chargetype;
           ExecuteQuery("SPDelInboundDetails", objp);
       }

       public void DeleteInboundHead(int inboundid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@inboundid", SqlDbType.Int, 4),
                   
                                                     };
           objp[0].Value = inboundid;
           ExecuteQuery("SPDelInboundHead", objp);
       }
       
       public DataTable GetInboundDetailsChargeId(int inboundid, int chargeid,string ctype,string cbase)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@inboundid", SqlDbType.Int, 4),
                                                new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                new SqlParameter("@ctype", SqlDbType.Char,1),
                                                new SqlParameter("@base",SqlDbType.VarChar,6)

                                                
                                                    };
           objp[0].Value = inboundid;
           objp[1].Value = chargeid;
           objp[2].Value = ctype;
           objp[3].Value = cbase;
           
           return ExecuteTable("SPGetInboundDetailsChargeId", objp);
       }

       //getmasterinboundbyagent
       
           public DataTable GetInboundheaddtlsbyagent(int agentid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@agentid", SqlDbType.Int, 4)
                                                

                                                
                                                    };
           objp[0].Value = agentid;
          

           return ExecuteTable("SPGetinboundheadbyagent", objp);
       }

       public void InsMasterRDS(int branchid, int agentid, int rds)
       {
           SqlParameter[] objp = new SqlParameter[] { 
               new SqlParameter("@bid", SqlDbType.Int, 4),
                                                        new SqlParameter("@agentid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rds", SqlDbType.Int)
                                                       };
           objp[0].Value = branchid;
           objp[1].Value = agentid;
           objp[2].Value = rds;
           ExecuteQuery("SPInsMasterRDS", objp);

       }


       public DataTable GetMASterRDS(int branchid, int agentid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                               new SqlParameter("@bid", SqlDbType.Int, 4),
                                                        new SqlParameter("@agentid", SqlDbType.Int, 4)
                                                

                                                
                                                    };
           objp[0].Value = branchid;
           objp[1].Value = agentid;
           return ExecuteTable("SPSelMasterRDS", objp);
       }

       //************************************************************Guru******************************************************

       public DataTable GetChargeidNew(string Chargename)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100) };

           objp[0].Value = Chargename;
           return ExecuteTable("SPChargeidCName", objp);


       }

       public DataTable GetCurrIDNew(string Curr)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Curr", SqlDbType.VarChar, 3) };
           objp[0].Value = Curr;

           return ExecuteTable("SPGetCurrID", objp);

       }
    }
}
