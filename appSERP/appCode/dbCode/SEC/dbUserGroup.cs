using appSERP.appCode.dbCode.SEC.Abstract;
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
    public class dbUserGroup : IdbUserGroup
    {

        private IclsADO _clsADO;
        public dbUserGroup(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funUserGroupGET(
       int? pUserGroupId = null,
       int? pUserId = null,
       int? pGroupId = null,
       bool? pIsDeleted = null,
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
            vlstParam.Add(new SqlParameter("UserGroupId", pUserGroupId));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("GroupId", pGroupId));
            vlstParam.Add(new SqlParameter("CompanyId", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserGroupCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}