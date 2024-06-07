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
    public class dbInvItemsUnitsPrice: IdbInvItemsUnitsPrice
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvItemsUnitsPrice(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funInvItemsUnitsPriceGET(

        int? pPriceId = null,
        string pPriceCode = null,
        int? pItemId = null,
        int? pUnitId = null,
        int? pSellCostType = null,
         decimal? pPrice = null,
         int? pPriceCat = null,
        string pNotes = null,
        bool? pPriceIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("PriceId", pPriceId));
            vlstParam.Add(new SqlParameter("PriceCode", pPriceCode));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("SellCostType", pSellCostType));
            vlstParam.Add(new SqlParameter("Price", pPrice));
            vlstParam.Add(new SqlParameter("PriceCat", pPriceCat));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("PriceIsActive", pPriceIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvItemsUnitsPricesCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}