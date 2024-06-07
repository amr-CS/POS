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
    public class APIAssetTransController : ApiController
    {
        private IdbAssetTrans _dbAssetTrans;
        public APIAssetTransController(IdbAssetTrans dbAssetTrans) {
            _dbAssetTrans = dbAssetTrans;
        }

        [HttpGet]
        public string AssetTransGET(
        int? pAssetTransId = null,
        DateTime? pAssetTransDate = null,
        decimal? pAssetTransValue = null,
        decimal? pAssetTransValueBase = null,
        int? pCurrencyId = null,
        string pAssetReasonTypeNote = null,
        string pAssetTransNote = null,
        int? pAssetId = null,
        int? pTransactionTypeId = null,
        int? pAssetReasonTypeId = null,
        bool? pAssetTransIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
        // Set Data
        string vData = _dbAssetTrans.funAssetTransGET(
        pAssetTransId : pAssetTransId,
        pAssetTransDate : pAssetTransDate,
        pAssetTransValue : pAssetTransValue,
        pAssetTransValueBase : pAssetTransValueBase,
        pCurrencyId : pCurrencyId,
        pAssetReasonTypeNote : pAssetReasonTypeNote,
        pAssetTransNote : pAssetTransNote,
        pAssetId : pAssetId,
        pTransactionTypeId : pTransactionTypeId,
        pAssetReasonTypeId : pAssetReasonTypeId,
        pAssetTransIsActive : pAssetTransIsActive,
        pIsDeleted : pIsDeleted,
        pQueryTypeId : pQueryTypeId);
            // Get Data
            return vData;
        }
    }
}
