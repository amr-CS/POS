using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.Abstract;

namespace appSERP.appCode.dbCode.SEC
{
    public class dbSecurityPolicy : IdbSecurityPolicy
    {


        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSecurityPolicy(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSecurityPolicyGET(
        int? pSecurityPolicyId = null,
        int? pSecurityPolicySeq = null,
        string pSecurityPolicyNameL1 = null,
        string pSecurityPolicyNameL2 = null,
        bool? pSecurityPolicyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SecurityPolicyId", pSecurityPolicyId));
            vlstParam.Add(new SqlParameter("SecurityPolicySeq", pSecurityPolicySeq));
            vlstParam.Add(new SqlParameter("SecurityPolicyNameL1", pSecurityPolicyNameL1));
            vlstParam.Add(new SqlParameter("SecurityPolicyNameL2", pSecurityPolicyNameL2));
            vlstParam.Add(new SqlParameter("SecurityPolicyIsActive", pSecurityPolicyIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spSecurityPolicyCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}