using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbStore: IdbStore
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbStore(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funStoreGET(

        int? pStoreId = null,
        string pStoreCode = null,
        string pStoreNameL1 = null,
        string pStoreNameL2 = null,
        string pStoreShortName = null,
        int? pStoreTypeId = null,
        int? pCountryId = null,
        int? pCityId = null,
        string pStoreNotes = null,
        string pStorePhone = null,
        string pStoreAddress = null,
        bool? pStoreIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("StoreCode", pStoreCode));
            vlstParam.Add(new SqlParameter("StoreNameL1", pStoreNameL1));
            vlstParam.Add(new SqlParameter("StoreNameL2", pStoreNameL2));
            vlstParam.Add(new SqlParameter("StoreShortName", pStoreShortName));
            vlstParam.Add(new SqlParameter("StoreTypeId", pStoreTypeId));
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("CityId", pCityId));
            vlstParam.Add(new SqlParameter("StoreNotes ", pStoreNotes));
            vlstParam.Add(new SqlParameter("StorePhone", pStorePhone));
            vlstParam.Add(new SqlParameter("StoreAddress", pStoreAddress));
            vlstParam.Add(new SqlParameter("StoreIsActive", pStoreIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spStoreCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}