using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.FA
{
    public class dbAsset : IdbAsset
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbAsset(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAssetGET(
        int? pAssetId = null,
        string pAssetCode = null,
        string pAssetNameL1 = null,
        string pAssetNameL2 = null,
        int? pAssetQty = null,
        int? pSiteId=null,
        decimal? pAssetPurchasePrice = null,
        int? pCurrencyId = null,
        decimal? pCurrencyValue = null,
        decimal? pAssetPurchasePriceBase = null,
        decimal? pAssetBookValue = null,
        decimal? pAssetBookValueBase = null,
        int? pAssetPercent = null,
        DateTime? pAssetLastDepDate = null,
        DateTime? pPostDate = null,
        int? pAssetTotalDep = null,
        int? pAssetTotalDepBase = null,
        int? pBillNo = null,
        int? pPurchaseNo = null,
        DateTime? pPurchaseDate = null,
        int? pBranchId = null,
        bool? pIsAutoPost = null,
        bool? pIsPosted = null,
        decimal? pAssetDebitAccount = null,
        decimal? pAssetCreditAccount = null,
        decimal? pAssetPurchaseAccount = null,
        decimal? pAssetSalesAccount = null,
        int? pAssetAccountId = null,
        int? pAssetSupplierId = null,
        string pAssetSupplierName = null,
        decimal? pAssetMinPrice = null,
        decimal? pAssetMinPriceBase = null,
        int? pCompanyId = null,
        int? pProductPeriod = null,
        int? pInvItemId = null,
        int? pMainGroupId = null,
        int? pGroupId = null,
        string pInvItemName = null,
        int? pFixedAssetMethodId = null,
        int? pFixedAssetUnitId = null,
        int? pDonorId = null,
        int? pBuyGroupId = null,
        int? pFixedAssetCompanyId = null,
        bool? pAssetIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null,
        string pLstGroup = null,
        string pLstMethod = null,
        string pLstSupplier = null,
        string pLstBuyGroup = null
        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AssetId", pAssetId));
            vlstParam.Add(new SqlParameter("AssetCode", pAssetCode));
            vlstParam.Add(new SqlParameter("AssetNameL1", pAssetNameL1));
            vlstParam.Add(new SqlParameter("AssetNameL2", pAssetNameL2));
            vlstParam.Add(new SqlParameter("AssetQty", pAssetQty));
            vlstParam.Add(new SqlParameter("SiteId", pSiteId));
            vlstParam.Add(new SqlParameter("AssetPurchasePrice", pAssetPurchasePrice));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("CurrencyValue", pCurrencyValue));
            vlstParam.Add(new SqlParameter("AssetPurchasePriceBase", pAssetPurchasePriceBase));
            vlstParam.Add(new SqlParameter("AssetBookValue", pAssetBookValue));
            vlstParam.Add(new SqlParameter("AssetBookValueBase", pAssetBookValueBase));
            vlstParam.Add(new SqlParameter("AssetPercent", pAssetPercent));
            vlstParam.Add(new SqlParameter("AssetLastDepDate", pAssetLastDepDate));
            vlstParam.Add(new SqlParameter("PostDate", pPostDate));
            vlstParam.Add(new SqlParameter("AssetTotalDep", pAssetTotalDep));
            vlstParam.Add(new SqlParameter("AssetTotalDepBase", pAssetTotalDepBase));
            vlstParam.Add(new SqlParameter("BillNo", pBillNo));
            vlstParam.Add(new SqlParameter("PurchaseNo", pPurchaseNo));
            vlstParam.Add(new SqlParameter("PurchaseDate", pPurchaseDate));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("IsAutoPost", pIsAutoPost));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("AssetDebitAccount", pAssetDebitAccount));
            vlstParam.Add(new SqlParameter("AssetCreditAccount", pAssetCreditAccount));
            vlstParam.Add(new SqlParameter("AssetPurchaseAccount", pAssetPurchaseAccount));
            vlstParam.Add(new SqlParameter("AssetSalesAccount", pAssetSalesAccount));
            vlstParam.Add(new SqlParameter("AssetAccountId", pAssetAccountId));
            vlstParam.Add(new SqlParameter("AssetSupplierId", pAssetSupplierId));
            vlstParam.Add(new SqlParameter("AssetSupplierName", pAssetSupplierName));
            vlstParam.Add(new SqlParameter("AssetMinPrice", pAssetMinPrice));
            vlstParam.Add(new SqlParameter("AssetMinPriceBase", pAssetMinPriceBase));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("ProductPeriod", pProductPeriod));
            vlstParam.Add(new SqlParameter("InvItemId", pInvItemId));
            vlstParam.Add(new SqlParameter("InvItemName", pInvItemName));
            vlstParam.Add(new SqlParameter("FixedAssetMethodId", pFixedAssetMethodId));
            vlstParam.Add(new SqlParameter("FixedAssetUnitId", pFixedAssetUnitId));
            vlstParam.Add(new SqlParameter("DonorId", pDonorId));
            vlstParam.Add(new SqlParameter("BuyGroupId", pBuyGroupId));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyId", pFixedAssetCompanyId));
            vlstParam.Add(new SqlParameter("AssetIsActive", pAssetIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("LstGroup", pLstGroup));
            vlstParam.Add(new SqlParameter("LstMethod", pLstMethod));
            vlstParam.Add(new SqlParameter("LstSupplier", pLstSupplier));
            vlstParam.Add(new SqlParameter("LstBuyGroup", pLstBuyGroup));
            vData = _clsADO.funExecuteScalar("FA.spAssetCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }



        public string funAssetEXCELSave(
        string pAssetNameL1 = null,
        string pAssetNameL2 = null,
        string pAssetCode = null,
        string pAssetQty = null,
        string pAssetPurchasePrice = null,
        string pCurrencyNameL1 = null,
        string pCurrencyValue = null,
        string pAssetPurchasePriceBase = null,
        string pAssetBookValue = null,
        string pAssetBookValueBase = null,
        string pAssetPercent = null,
        string pAssetLastDepDate = null,
        string pPostDate = null,
        string pBillNo = null,
        string pPurchaseNo = null,
        string pPurchaseDate = null,
        string pAssetSupplierName = null,
        string pAssetMinPrice = null,
        string pAssetMinPriceBase = null,
        string pProductPeriod = null,
        string pMainGroup = null,
        string pGroup = null,
        string pFixedAssetMethod = null,
        string pDonor = null,
        string pBuyGroup = null,
        string pFixedAssetCompanyName = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qInsert)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AssetCode", pAssetCode));
            vlstParam.Add(new SqlParameter("AssetNameL1", pAssetNameL1));
            vlstParam.Add(new SqlParameter("AssetNameL2", pAssetNameL2));
            vlstParam.Add(new SqlParameter("AssetQty", pAssetQty));
            vlstParam.Add(new SqlParameter("AssetPurchasePrice", pAssetPurchasePrice));
            vlstParam.Add(new SqlParameter("CurrencyNameL1", pCurrencyNameL1));
            vlstParam.Add(new SqlParameter("CurrencyValue", pCurrencyValue));
            vlstParam.Add(new SqlParameter("AssetPurchasePriceBase", pAssetPurchasePriceBase));
            vlstParam.Add(new SqlParameter("AssetBookValue", pAssetBookValue));
            vlstParam.Add(new SqlParameter("AssetBookValueBase", pAssetBookValueBase));
            vlstParam.Add(new SqlParameter("AssetPercent", pAssetPercent));
            vlstParam.Add(new SqlParameter("AssetLastDepDate", pAssetLastDepDate));
            vlstParam.Add(new SqlParameter("PostDate", pPostDate));
            vlstParam.Add(new SqlParameter("BillNo", pBillNo));
            vlstParam.Add(new SqlParameter("PurchaseNo", pPurchaseNo));
            vlstParam.Add(new SqlParameter("PurchaseDate", pPurchaseDate));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("AssetSupplierName", pAssetSupplierName));
            vlstParam.Add(new SqlParameter("AssetMinPrice", pAssetMinPrice));
            vlstParam.Add(new SqlParameter("AssetMinPriceBase", pAssetMinPriceBase));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("ProductPeriod", pProductPeriod));
            vlstParam.Add(new SqlParameter("MainGroup", pMainGroup));
            vlstParam.Add(new SqlParameter("Group", pGroup));
            vlstParam.Add(new SqlParameter("FixedAssetMethod", pFixedAssetMethod));
            vlstParam.Add(new SqlParameter("Donor", pDonor));
            vlstParam.Add(new SqlParameter("BuyGroup", pBuyGroup));
            vlstParam.Add(new SqlParameter("FixedAssetCompanyName", pFixedAssetCompanyName));
            vlstParam.Add(new SqlParameter("AssetIsActive", true));
            vlstParam.Add(new SqlParameter("IsDeleted", false));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spAssetExcel", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetAssetReport(bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("FA.spAssetReport", vlstParam, "Data GET");


            return vData;
        }
    }
}