using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbTimeZone : IdbTimeZone
    {

        private IclsADO _clsADO;
        public dbTimeZone(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funTimeZoneGET(
        int? pTimeZoneId = null,
        int? pTimeZoneName = null,
        TimeSpan? pTimeZoneOffset = null,
        bool? pTimeZoneIsActive = null,
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
            vlstParam.Add(new SqlParameter("TimeZoneId", pTimeZoneId));
            vlstParam.Add(new SqlParameter("TimeZoneName", pTimeZoneName));
            vlstParam.Add(new SqlParameter("TimeZoneOffset", pTimeZoneOffset));
            vlstParam.Add(new SqlParameter("TimeZoneIsActive", pTimeZoneIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spTimeZoneCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}