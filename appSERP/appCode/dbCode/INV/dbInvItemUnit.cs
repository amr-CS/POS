using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbInvItemUnit: IdbInvItemUnit
    {
        

        public  string vSQLResult { get; set; }
        public  int vSQLResultTypeId { get; set; }
        public  DataTable vDtDataContent { get; set; }
        public  DataTable vDtDataItemPrice { get; set; }
        public DataTable vDtDataUnit { get; set; }

        private IclsADO _clsADO;
        public dbInvItemUnit(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funInvItemUnitGET(
         int? pInvItemUnitId = null,
        int? pUnitId = null,
        string pUnitCode = null,
        string pUnitNameL1 = null,
        string pUnitNameL2 = null,
        int? pUnitParentId = null,
        decimal? pUnitCost = null,
        float? pPartsInParents = null,
        decimal? pUnitPrice = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pPriceCurrency = null,
        int? pDefaultUnit = null,
        decimal? pUnitOrderLimit = null,
        int? pItemId = null,
        int? pBranchId = null,
        string pBarcode = null,
        bool? pIsDecreasable = null,
        bool? pSellUnit = null,
        bool? pUnitProduction = null,
        bool?  pIsDefault = null,
        bool? pUnitIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemUnitId", pInvItemUnitId));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("UnitCode", pUnitCode));
            vlstParam.Add(new SqlParameter("UnitNameL1", pUnitNameL1));
            vlstParam.Add(new SqlParameter("UnitNameL2", pUnitNameL2));
            vlstParam.Add(new SqlParameter("UnitParentId", pUnitParentId));
            vlstParam.Add(new SqlParameter("UnitCost", pUnitCost));
            vlstParam.Add(new SqlParameter("PartsInParents", pPartsInParents));
            vlstParam.Add(new SqlParameter("UnitPrice", pUnitPrice));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("PriceCurrency", pPriceCurrency));
            vlstParam.Add(new SqlParameter("DefaultUnit", pDefaultUnit));
            vlstParam.Add(new SqlParameter("UnitOrderLimit", pUnitOrderLimit));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("Barcode", pBarcode));
            vlstParam.Add(new SqlParameter("IsDecreasable", pIsDecreasable));
            vlstParam.Add(new SqlParameter("SellUnit", pSellUnit));
            vlstParam.Add(new SqlParameter("UnitProduction", pUnitProduction));
            vlstParam.Add(new SqlParameter("IsDefault", pIsDefault));
            vlstParam.Add(new SqlParameter("UnitIsActive", pUnitIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spINVItemUnitCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        const string tableName = "INV.tblInvItemUnit";

        /// <summary>
        /// جلب وحدات الصنف
        /// </summary>
        /// <param name="ItemId">رقم الصنف</param>
        /// <returns></returns>
        public DataTable GetItemUnits(int ItemId)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "ItemId=@itemId";
            vlstParam.Add(new SqlParameter("@itemId", ItemId));
            string queryText = $"select * from {tableName} where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }
        /// <summary>
        /// جلب وحدة صنف محدد بواسطة رقم وحدة الصنف      
        /// </summary>
        /// <param name="InvItemUnitId">رقم وحدة الصنف</param>
        /// <returns></returns>
        public DataTable GetItemUnitById(int InvItemUnitId)
        {           
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "InvItemUnitId=@invItemUnitId";          
             vlstParam.Add(new SqlParameter("@invItemUnitId", InvItemUnitId));                        
            string queryText = $"select * from {tableName} where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }
        /// <summary>
        /// استرجاع للفحص هل وحدة الصنف التي تريد حذفها تعتبر وحدة اب لوحدة صنف أخرى
        /// </summary>
        /// <param name="UnitParentId">رقم وحدة الصنف الاب</param>
        /// <param name="ItemId">رقم الصنف</param>
        /// <returns></returns>
        public DataTable GetItemUnitParentBy(int UnitParentId,int ItemId)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "UnitParentId=@unitParentId and ItemId=@itemId";
            vlstParam.Add(new SqlParameter("@unitParentId", UnitParentId));
            vlstParam.Add(new SqlParameter("@itemId", ItemId));
            string queryText = $"select * from {tableName} where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }

    }
}