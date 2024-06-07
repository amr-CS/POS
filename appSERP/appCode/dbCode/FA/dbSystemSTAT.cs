using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.FA
{
    public class dbSystemSTAT : IdbSystemSTAT
    {

        private IclsADO _clsADO;
        public dbSystemSTAT(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSystemSTATGET()
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vData = _clsADO.funExecuteScalar("FA.spSystemSTAT", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}