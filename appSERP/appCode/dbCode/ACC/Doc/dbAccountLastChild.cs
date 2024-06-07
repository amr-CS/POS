using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace appSERP.appCode.dbCode.ACC.Doc
{
    // Account Last Child
    public class dbAccountLastChild : IdbAccountLastChild
    {

        private IclsADO _clsADO;
        public dbAccountLastChild(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        // AccountLastChild
        public string funAccountLastChildGET(
            int? pParentId = null,
            int? pAccountId = null,
            string pAccountNo = null,
            bool? AccountIsActive = null,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("pParentId", pParentId));
            vlstParam.Add(new SqlParameter("pAccountId", pAccountId));
            vlstParam.Add(new SqlParameter("pAccountNo", pAccountNo));
            vlstParam.Add(new SqlParameter("AccountIsActive", AccountIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", false));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spAccountGET", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}