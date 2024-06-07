using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.GD
{
    public class dbCompanySystem: IdbCompanySystem
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCompanySystem(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCompanySystemGET(
        int? pCompanySystemId = null,
        string pCompanySystemCode = null,
        int? pAccountId = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCompanySystemIsActive = null,
        int? pSystemId = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanySystemId", pCompanySystemId));
            vlstParam.Add(new SqlParameter("CompanySystemCode", pCompanySystemCode));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CompanySystemIsActive", pCompanySystemIsActive));
            vlstParam.Add(new SqlParameter("SystemId", pSystemId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("GD.spCompanySystemCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}