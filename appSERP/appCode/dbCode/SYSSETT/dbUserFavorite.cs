using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbUserFavorite: IdbUserFavorite
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbUserFavorite(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funUserFavoriteGET(
       int? pUserFavoriteId = null,
       int? pUserId = null,
       int? pObjectId = null,
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
            vlstParam.Add(new SqlParameter("UserFavoriteId", pUserFavoriteId));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("ObjectId", pObjectId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", pCreatedBy));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", pLastUpdatedBy));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spUserFavoriteCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}