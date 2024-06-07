using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbStoreSetting: IdbStoreSetting
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbStoreSetting(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funStoreSettingGET(

        int? pStoreSettingId = null,
        string pStoreSettingCode = null,
        string pStoreSettingNameL1 = null,
        string pStoreSettingNameL2 = null,
        string pStoreSettingNotes = null,
        int?   pStoreId           = null,
        bool? pStoreSettingIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreSettingId", pStoreSettingId));
            vlstParam.Add(new SqlParameter("StoreSettingCode", pStoreSettingCode));
            vlstParam.Add(new SqlParameter("StoreSettingNameL1", pStoreSettingNameL1));
            vlstParam.Add(new SqlParameter("StoreSettingNameL2", pStoreSettingNameL2));
            vlstParam.Add(new SqlParameter("StoreSettingNotes", pStoreSettingNotes));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("StoreSettingIsActive", pStoreSettingIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spStoreSettingCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}