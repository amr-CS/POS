using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.FA
{
    public class dbAssetTrust
    {
        // Message
        public static string vSQLResult;
        public static int vSQLResultTypeId;

        public static string funAssetTrustGET(
        int? pAssetTrustId = null,
        int? pAssetId       = null,
        int? pTrustId       = null,
        bool? pAssetTrustIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AssetTrustId", pAssetTrustId));
            vlstParam.Add(new SqlParameter("AssetId", pAssetId));
            vlstParam.Add(new SqlParameter("TrustId", pTrustId));
            vlstParam.Add(new SqlParameter("AssetTrustIsActive", pAssetTrustIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = clsADO.funExecuteScalar("FA.spAssetTrustCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}