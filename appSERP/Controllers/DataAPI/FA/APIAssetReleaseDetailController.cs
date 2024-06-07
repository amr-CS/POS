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
    public class APIAssetReleaseDetailController : ApiController
    {
        private IdbAssetReleaseDetail _dbAssetReleaseDetail;
        public APIAssetReleaseDetailController(IdbAssetReleaseDetail dbAssetReleaseDetail) {
            _dbAssetReleaseDetail = dbAssetReleaseDetail;
        }

        [HttpGet]
        public string AssetReleaseDetailGET(
        int? pAssetReleaseDetailId = null,
        string pAssetReleaseDetailNameL1 = null,
        string pAssetReleaseDetailNameL2 = null,
        string pAssetReleaseDetailCode = null,
        int? pAssetReleaseQty = null,
        int? pAssetReleaseSeq = null,
        int? pAssetReleaseId = null,
        int? pAssetId = null,
        bool? pAssetReleaseDetailIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data 
            string vData = _dbAssetReleaseDetail.funAssetReleaseDetailGET(
            pAssetReleaseDetailId: pAssetReleaseDetailId,
            pAssetReleaseDetailNameL1: pAssetReleaseDetailNameL1,
            pAssetReleaseDetailNameL2: pAssetReleaseDetailNameL2,
            pAssetReleaseDetailCode: pAssetReleaseDetailCode,
            pAssetReleaseQty: pAssetReleaseQty,
            pAssetReleaseSeq: pAssetReleaseSeq,
            pAssetReleaseId: pAssetReleaseId,
            pAssetId: pAssetId,
            pAssetReleaseDetailIsActive: pAssetReleaseDetailIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Get Data
            return vData;
        }
    }
}