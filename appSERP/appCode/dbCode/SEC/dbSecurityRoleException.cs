using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.SEC
{
    public class dbSecurityRoleException: IdbSecurityRoleException
    {

        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSecurityRoleException(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funSecurityRoleExceptionGET(
        int? pSecurityRoleExceptionId = null,
        string pSecurityRoleExceptionCode = null,
        string pSecurityRoleExceptionNameL1 = null,
        string pSecurityRoleExceptionNameL2 = null,
        bool? pSecurityRoleExceptionIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SecurityRoleExceptionId", pSecurityRoleExceptionId));
            vlstParam.Add(new SqlParameter("SecurityRoleExceptionCode", pSecurityRoleExceptionCode));
            vlstParam.Add(new SqlParameter("SecurityRoleExceptionNameL1", pSecurityRoleExceptionNameL1));
            vlstParam.Add(new SqlParameter("SecurityRoleExceptionNameL2", pSecurityRoleExceptionNameL2));
            vlstParam.Add(new SqlParameter("SecurityRoleExceptionIsActive", pSecurityRoleExceptionIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spSecurityRoleExceptionCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

    }
}