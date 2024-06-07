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
    public class dbSecurityRole: IdbSecurityRole
    {

        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        // SecurityRoleId
        public string vSecurityRoleId { get; set; }

        private IclsADO _clsADO;
        public dbSecurityRole(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        

        public string funSecurityRoleGET(
        int? pSecurityRoleId = null,
        string pSecurityRoleNameL1 = null,
        string pSecurityRoleNameL2 = null,
        bool? pSecurityRoleIsActive = null,
        bool? pIsMaster = null,
        int? pCompanyId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pSecurityRoleObjectId = null,
        int? pObjectId = null,
        int? pUserId = null,
        string pObjectAction = null,
        int? pQueryTypeId = null  )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SecurityRoleId", pSecurityRoleId));
            vlstParam.Add(new SqlParameter("SecurityRoleNameL1", pSecurityRoleNameL1));
            vlstParam.Add(new SqlParameter("SecurityRoleNameL2", pSecurityRoleNameL2));
            vlstParam.Add(new SqlParameter("IsMaster", pIsMaster));
            vlstParam.Add(new SqlParameter("SecurityRoleIsActive", pSecurityRoleIsActive));
            vlstParam.Add(new SqlParameter("SecurityRoleObjectId", pSecurityRoleObjectId));
            vlstParam.Add(new SqlParameter("ObjectId", pObjectId));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("ObjectAction", pObjectAction));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spSecurityRole", vlstParam, "Data GET").ToString();
            return vData;
        }




    }
}