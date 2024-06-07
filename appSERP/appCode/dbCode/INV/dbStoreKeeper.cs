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
    public class dbStoreKeeper : IdbStoreKeeper
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbStoreKeeper(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funStoreKeeperGET(

        int? pStoreKeeperId = null,
        string pStoreKeeperCode = null,
        string pStoreKeeperNameL1 = null,
        string pStoreKeeperNameL2 = null,
        int? pStoreId = null,
        bool? pStoreKeeperIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreKeeperId", pStoreKeeperId));
            vlstParam.Add(new SqlParameter("StoreKeeperCode", pStoreKeeperCode));
            vlstParam.Add(new SqlParameter("StoreKeeperNameL1", pStoreKeeperNameL1));
            vlstParam.Add(new SqlParameter("StoreKeeperNameL2", pStoreKeeperNameL2));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("StoreKeeperIsActive", pStoreKeeperIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            vData = _clsADO.funExecuteScalar("INV.spStoreKeeperCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}