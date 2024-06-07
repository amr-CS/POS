using appSERP.appCode.dbCode.ACC.Abstract;
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

namespace appSERP.appCode.dbCode.ACC
{
    public class dbSellCostType: IdbSellCostType
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSellCostType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funSellCostTypeGET(
         int? pSellCostTypeId = null,
       string pSellCostTypeCode = null,
         string pSellCostTypeNameL1 = null,
         string pSellCostTypeNameL2 = null,
         bool? pSellCostTypeIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("SellCostTypeId", pSellCostTypeId));
            vlstParam.Add(new SqlParameter("SellCostTypeCode", pSellCostTypeCode));
            vlstParam.Add(new SqlParameter("SellCostTypeNameL1", pSellCostTypeNameL1));
            vlstParam.Add(new SqlParameter("SellCostTypeNameL2", pSellCostTypeNameL2));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spSellCostTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}