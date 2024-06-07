using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAsset
    {
        string funAssetGET(
        int? pAssetId = null,
        string pAssetCode = null,
        string pAssetNameL1 = null,
        string pAssetNameL2 = null,
        int? pAssetQty = null,
        int? pSiteId = null,
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
        string pLstBuyGroup = null);

        string funAssetEXCELSave(
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
        int? pQueryTypeId = clsQueryType.qInsert);

        DataTable funGetAssetReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
