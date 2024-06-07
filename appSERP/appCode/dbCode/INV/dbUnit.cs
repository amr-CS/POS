using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.Company;
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
    public class dbUnit : IdbUnit
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbUnit(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funUnitGET(

        int? pUnitId = null,
        string pUnitCode = null,
        string pUnitNameL1 = null,
        string pUnitNameL2 = null,
        int? pUnitParentId = null,
        int? pPartsInParents = null,
        decimal? pUnitPrice = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pPriceCurrency = null,
        int? pDefaultUnit = null,
        decimal? pUnitOrderLimit = null ,
         int? pItemId = null,
        int? pBranchId = null,
        bool? pUnitIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("UnitCode", pUnitCode));
            vlstParam.Add(new SqlParameter("UnitNameL1", pUnitNameL1));
            vlstParam.Add(new SqlParameter("UnitNameL2", pUnitNameL2));
            vlstParam.Add(new SqlParameter("UnitParentId", pUnitParentId));
            vlstParam.Add(new SqlParameter("PartsInParents", pPartsInParents));
            vlstParam.Add(new SqlParameter("UnitPrice", pUnitPrice));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("PriceCurrency", pPriceCurrency));
            vlstParam.Add(new SqlParameter("DefaultUnit", pDefaultUnit));
            vlstParam.Add(new SqlParameter("UnitOrderLimit", pUnitOrderLimit));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("UnitIsActive", pUnitIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spUnitCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}