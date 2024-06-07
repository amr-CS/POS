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
    public class dbCategoryAccount : IdbCategoryAccount
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCategoryAccount(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funCategoryAccountGET(

        int? pCategoryAccountId = null,
        string pCategoryAccountCode = null,
        string pCategoryAccountNameL1 = null,
        string pCategoryAccountNameL2 = null,
        int? pCurrencyId = null,
        int? pAccountId = null,
        int? pSalesAccountId = null,
        int? pReturnSalesAccountId = null,
        int? pDiscountReceivedId = null,
        int? pDiscountAllowedId = null,
        int? pTaxAccountId = null,
        int? pGroupAccountId = null,
        int? pReturnPurchasesAccountId = null,
        int? pSalesCostAccountId = null,
        int? pProductTypeId = null,
        bool? pCategoryAccountIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CategoryAccountId", pCategoryAccountId));
            vlstParam.Add(new SqlParameter("CategoryAccountCode", pCategoryAccountCode));
            vlstParam.Add(new SqlParameter("CategoryAccountNameL1", pCategoryAccountNameL1));
            vlstParam.Add(new SqlParameter("CategoryAccountNameL2", pCategoryAccountNameL2));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("SalesAccountId", pSalesAccountId));
            vlstParam.Add(new SqlParameter("ReturnSalesAccountId", pReturnSalesAccountId));
            vlstParam.Add(new SqlParameter("DiscountReceivedId", pDiscountReceivedId));
            vlstParam.Add(new SqlParameter("DiscountAllowedId", pDiscountAllowedId));
            vlstParam.Add(new SqlParameter("TaxAccountId", pTaxAccountId));
            vlstParam.Add(new SqlParameter("GroupAccountId", pGroupAccountId));
            vlstParam.Add(new SqlParameter("ReturnPurchasesAccountId", pReturnPurchasesAccountId));
            vlstParam.Add(new SqlParameter("SalesCostAccountId", pSalesCostAccountId));
            vlstParam.Add(new SqlParameter("ProductTypeId", pProductTypeId));
            vlstParam.Add(new SqlParameter("CategoryAccountIsActive", pCategoryAccountIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spCategoryAccountCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}