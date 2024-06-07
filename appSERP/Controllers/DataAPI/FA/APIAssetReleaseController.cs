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
    public class APIAssetReleaseController : ApiController
    {
        private IdbAssetRelease _dbAssetRelease;
        public APIAssetReleaseController(IdbAssetRelease dbAssetRelease) {
            _dbAssetRelease = dbAssetRelease;
        }

        [HttpGet]
        public string AssetReleaseGET(
       int? pAssetReleaseId = null,
       string pAssetReleaseNameL1 = null,
       string pAssetReleaseNameL2 = null,
       string pAssetReleaseCode = null,
       DateTime? pAssetReleaseDate = null,
       int? pTrustId = null,
       int? pTransactionTypeId = null,
       string pNote = null,
       bool? pAssetReleaseIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // SET Data
            string vData = _dbAssetRelease.funAssetReleaseGET(
        pAssetReleaseId: pAssetReleaseId,
        pAssetReleaseNameL1: pAssetReleaseNameL1,
        pAssetReleaseNameL2: pAssetReleaseNameL2,
        pAssetReleaseCode: pAssetReleaseCode,
        pAssetReleaseDate: pAssetReleaseDate,
        pTrustId: pTrustId,
        pTransactionTypeId: pTransactionTypeId,
        pNote: pNote,
        pAssetReleaseIsActive: pAssetReleaseIsActive,
        pIsDeleted: pIsDeleted,
        pQueryTypeId: pQueryTypeId);
            // Get Data
            return vData;

        }
        }
}
