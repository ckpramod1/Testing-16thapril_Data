using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DataAccess.TruckHandling
{
    public class MasterRoute : DBObject
    {

       
        public DataSet GetAllRoutes()
        {
            return ExecuteDataSet("SPSelALLRoutes");
        }
    }
}
