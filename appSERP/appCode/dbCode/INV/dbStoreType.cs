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
    public class dbStoreType: IdbStoreType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbStoreType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funStoreTypeGET(

        int? pStoreTypeId = null,
        string pStoreTypeCode = null,
        string pStoreTypeNameL1 = null,
        string pStoreTypeNameL2 = null,
        int?   pStoreId         = null,
        bool? pStoreTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreTypeId", pStoreTypeId));
            vlstParam.Add(new SqlParameter("StoreTypeCode", pStoreTypeCode));
            vlstParam.Add(new SqlParameter("StoreTypeNameL1", pStoreTypeNameL1));
            vlstParam.Add(new SqlParameter("StoreTypeNameL2", pStoreTypeNameL2));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("StoreTypeIsActive", pStoreTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spStoreTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}