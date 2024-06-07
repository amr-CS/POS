using appSERP.appCode.dbCode.FA;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIAssetExcelController : ApiController
    {
        [HttpGet]
        public string AssetEXCELSave(
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
        int? pQueryTypeId = clsQueryType.qInsert)
         {
            // Set Data
            string vData = dbAsset.funAssetEXCELSave(
            pAssetNameL1: pAssetNameL1.Trim(),
            pAssetNameL2: pAssetNameL2.Trim(),
            pAssetCode: pAssetCode,
            pAssetQty: pAssetQty,
            pAssetPurchasePrice: pAssetPurchasePrice,
            pCurrencyNameL1: pCurrencyNameL1.Trim(),
            pCurrencyValue: pCurrencyValue,
            pAssetPurchasePriceBase: pAssetPurchasePriceBase,
            pAssetBookValue: pAssetBookValue,
            pAssetBookValueBase: pAssetBookValueBase,
            pAssetPercent: pAssetPercent,
            pAssetLastDepDate: pAssetLastDepDate,
            pPostDate: pPostDate,
            pBillNo: pBillNo,
            pPurchaseNo: pPurchaseNo,
            pPurchaseDate: pPurchaseDate,
            pAssetSupplierName: pAssetSupplierName.Trim(),
            pAssetMinPrice: pAssetMinPrice,
            pAssetMinPriceBase: pAssetMinPriceBase,
            pProductPeriod: pProductPeriod,
            pMainGroup: pMainGroup.Trim(),
            pGroup: pGroup.Trim(),
            pFixedAssetMethod: pFixedAssetMethod.Trim(),
            pDonor: pDonor.Trim(),
            pBuyGroup: pBuyGroup.Trim(),
            pFixedAssetCompanyName: pFixedAssetCompanyName.Trim(),
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            return vData;
        }
    }
}
