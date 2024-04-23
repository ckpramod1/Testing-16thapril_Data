using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class ServicetaxReg:DBObject
    {
       
       
       public double dblnontaxamnt, dbltaxableamnt, dbltaxamnt;
       public static string TempDBName="FATemp";

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ServicetaxReg()
        {
            Conn = new SqlConnection(DBCS);
        }

        public double GetNonTaxAmnt(int invoiceno, char voutype,int branchid,string trantype)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                    new SqlParameter("@voutype",SqlDbType.Char,1),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2)};
           objp[0].Value = invoiceno;
           objp[1].Value = voutype;
           objp[2].Value = branchid;
           objp[3].Value = trantype;
           dblnontaxamnt = double.Parse(ExecuteReader("SPGetIPNonTaxAmnt",objp));
           return dblnontaxamnt;

       }

       public double GetTaxableAmnt(int invoiceno, char voutype,int branchid,string trantype)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                   new SqlParameter("@voutype",SqlDbType.Char,1),
                                                   new SqlParameter("@branchid",SqlDbType.Int),
                                                   new SqlParameter("@trantype",SqlDbType.VarChar,2)};
           objp[0].Value = invoiceno;
           objp[1].Value = voutype;
           objp[2].Value = branchid;
           objp[3].Value = trantype;
           dbltaxableamnt = double.Parse(ExecuteReader("SPGetIPTaxableAmnt", objp));
           return dbltaxableamnt;

       }
       public double GetTaxAmnt(int invoiceno, char voutype,int branchid,string trantype)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                    new SqlParameter("@voutype",SqlDbType.Char,1),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2)};
           objp[0].Value = invoiceno;
           objp[1].Value = voutype;
           objp[2].Value = branchid;
           objp[3].Value = trantype;
           dbltaxamnt = double.Parse(ExecuteReader("SPGetIPTaxAmnt", objp));
           return dbltaxamnt;
       }

       public DataTable GetPAChargeNo(int pano, int branchid, int vouyear)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@pano",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
           objp[0].Value = pano;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           return ExecuteTable("SPGetPAChargeno", objp);
       }

       public DataTable GetDNChargeNo(int dnno, int branchid, int vouyear)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dnno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
           objp[0].Value = dnno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           return ExecuteTable("SPGetDNChargeno", objp);
       }

       public DataTable GetCNChargeNo(int cnno, int branchid, int vouyear)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@cnno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
           objp[0].Value = cnno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           return ExecuteTable("SPGetCNChargeno", objp);
       }

       public DataTable GetInvChargeNo(int invno, int branchid, int vouyear)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@invno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
           objp[0].Value = invno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           return ExecuteTable("SPGetInvChargeno", objp);
       }
       public int GetChargeSTNo(int chargeid)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@chargeid",SqlDbType.Int)};
           objp[0].Value = chargeid;
           return int.Parse(ExecuteReader("SPGetChargeSTno", objp));
       }
       public int GetChargeSTEDNo(int chargeid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) };
           objp[0].Value = chargeid;
           return int.Parse(ExecuteReader("SPGetChargeSTEDno", objp));
       }
       public int GetChargeNonSTNo(int chargeid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) };
           objp[0].Value = chargeid;
           return int.Parse(ExecuteReader("SPGetChargeNonSTno", objp));
       }
       public double GetPATaxAmnt(int pano, int chargeid, int branchid, int vouyear)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@pano",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@chargeid",SqlDbType.Int)};
           objp[0].Value = pano;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           objp[3].Value = chargeid;
           dbltaxamnt = double.Parse(ExecuteReader("SPGetPATaxableAmt", objp));
           return dbltaxamnt;
       }

       public double GetDNTaxAmnt(int dnno, int chargeid, int branchid, int vouyear)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dnno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@chargeid",SqlDbType.Int)};
           objp[0].Value = dnno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           objp[3].Value = chargeid;
           dbltaxamnt = double.Parse(ExecuteReader("SPGetDNTaxableAmt", objp));
           return dbltaxamnt;
       }

       public double GetCNTaxAmnt(int cnno, int chargeid, int branchid, int vouyear)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@cnno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@chargeid",SqlDbType.Int)};
           objp[0].Value = cnno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           objp[3].Value = chargeid;
           dbltaxamnt = double.Parse(ExecuteReader("SPGetCNTaxableAmt", objp));
           return dbltaxamnt;
       }

       public double GetInvTaxAmnt(int invno, int chargeid, int branchid, int vouyear)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@invno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@chargeid",SqlDbType.Int)};
           objp[0].Value = invno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           objp[3].Value = chargeid;
           dbltaxamnt = double.Parse(ExecuteReader("SPGetInvTaxableAmt", objp));
           return dbltaxamnt;
       }
       
       public DataTable GetAllInvoiceNo(DateTime fromdate, DateTime todate, int branchid,char voutype)
       {
           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@branchid",SqlDbType.Int,4),
                                                    new SqlParameter("@voutype",SqlDbType.Char,1)};
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           return ExecuteTable("SPSelTempInvPAdts",objp);
       }

       public void InsertServicetax(int vouno, DateTime voudate, int jobno,int customerid, double nontax, double taxable, double tax, int branchid, char voutype,int empid,string trantype)
       {

           SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@nontax",SqlDbType.Real,8),
                                                     new SqlParameter("@taxable",SqlDbType.Real,8),
                                                     new SqlParameter("@tax",SqlDbType.Real,8),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2)};
           objp[0].Value = vouno;
           objp[1].Value = voudate;
           objp[2].Value = jobno;
           objp[3].Value = customerid;
           objp[4].Value = nontax;
           objp[5].Value = taxable;
           objp[6].Value = tax;
           objp[7].Value = branchid;
           objp[8].Value = voutype;
           objp[9].Value = empid;
           objp[10].Value = trantype;
           ExecuteQuery("SPInsServicetax", objp);
       }
       public void InsertServicetaxNew(int branchid, char voutype, int empid, DateTime fromdate,DateTime todate)
       {

           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@empid",SqlDbType.Int)};
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           objp[4].Value = empid;
           ExecuteQuery("SPInsServicetaxNew", objp);
       }
       public DataTable SelServiceTaxReg(int branchid, char voutype, DateTime fromdate, DateTime todate)
       {

           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@type",SqlDbType.Char,1)};
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           return ExecuteTable("SPSelExcelSTReg", objp);
       }

       public void DeleteServicetax(int branchid, int empid)
       {           
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                   new SqlParameter("@empid",SqlDbType.Int,4)};
           objp[0].Value = branchid;
           objp[1].Value = empid;
           ExecuteQuery("SPDelServiceTaxReg", objp);

       }

      }
}
