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
    public class dbEmpStatus : IdbEmpStatus
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbEmpStatus(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funEmpStatusGET(
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
            vData = _clsADO.funExecuteScalar("RES.spEmpStatusCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}