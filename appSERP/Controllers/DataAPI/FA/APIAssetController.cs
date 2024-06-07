using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIAssetController : ApiController
    {
        private IdbAsset _dbAsset;
        public APIAssetController(IdbAsset dbAsset) {
            _dbAsset = dbAsset;
        }

        [HttpGet]
        public string AssetGET(
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
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect,
        string pLstGroup = null,
        string pLstMethod = null,
        string pLstSupplier = null,
        string pLstBuyGroup = null

        )
        {
           // Set Data
         string vData = _dbAsset.funAssetGET(
         pAssetId : pAssetId,
         pAssetCode : pAssetCode,
         pAssetNameL1 : pAssetNameL1,
         pAssetNameL2 : pAssetNameL2,
         pAssetQty : pAssetQty,
         pSiteId : pSiteId,
         pAssetPurchasePrice : pAssetPurchasePrice,
         pCurrencyId : pCurrencyId,
         pCurrencyValue : pCurrencyValue,
         pAssetPurchasePriceBase : pAssetPurchasePriceBase,
         pAssetBookValue : pAssetBookValue,
         pAssetBookValueBase : pAssetBookValueBase,
         pAssetPercent : pAssetPercent,
         pAssetLastDepDate : pAssetLastDepDate,
         pPostDate : pPostDate,
         pAssetTotalDep : pAssetTotalDep,
         pAssetTotalDepBase : pAssetTotalDepBase,
         pBillNo : pBillNo,
         pPurchaseNo : pPurchaseNo,
         pPurchaseDate : pPurchaseDate,
         pIsAutoPost : pIsAutoPost,
         pIsPosted : pIsPosted,
         pAssetDebitAccount : pAssetDebitAccount,
         pAssetCreditAccount : pAssetCreditAccount,
         pAssetPurchaseAccount : pAssetPurchaseAccount,
         pAssetSalesAccount : pAssetSalesAccount,
         pAssetAccountId : pAssetAccountId,
         pAssetSupplierId : pAssetSupplierId,
         pAssetSupplierName : pAssetSupplierName,
         pAssetMinPrice : pAssetMinPrice,
         pAssetMinPriceBase : pAssetMinPriceBase,
         pProductPeriod : pProductPeriod,
         pInvItemId : pInvItemId,
         pMainGroupId : pMainGroupId,
         pGroupId : pGroupId,
         pInvItemName : pInvItemName,
         pFixedAssetMethodId : pFixedAssetMethodId,
         pFixedAssetUnitId : pFixedAssetUnitId,
         pDonorId : pDonorId,
         pBuyGroupId : pBuyGroupId,
         pFixedAssetCompanyId : pFixedAssetCompanyId,
         pAssetIsActive : pAssetIsActive,
         pIsDeleted : pIsDeleted,
         pQueryTypeId : pQueryTypeId,
         pLstGroup: pLstGroup,
         pLstMethod: pLstMethod,
         pLstSupplier: pLstSupplier,
         pLstBuyGroup: pLstBuyGroup
         );
            // Return Data
            return vData;
        }
        
    }
}
