﻿using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbSalesMen : IdbSalesMen
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSalesMen(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSalesMenGET(
        int? pCodeId = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CodeId", pCodeId));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spSalesCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}