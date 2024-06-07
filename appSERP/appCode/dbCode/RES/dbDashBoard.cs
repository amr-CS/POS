using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbDashBoard : IdbDashBoard
    {
        private IclsADO _clsADO;
        public dbDashBoard(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funDashBoardGET()
        {
            // Declaration 
            string vData=string.Empty ;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
          
            vData = _clsADO.funExecuteScalar("RES.spDashBoard", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}