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
    public class APIFixedAssetSiteController : ApiController
    {
        private IdbFixedAssetSite _dbFixedAssetSite;
        public APIFixedAssetSiteController(IdbFixedAssetSite dbFixedAssetSite)
        {
            _dbFixedAssetSite = dbFixedAssetSite;
        }
        [HttpGet]
        public string FixedAssetSiteGET(
       int? pFixedAssetSiteId = null,
       int? pFixedAssetSiteQty = null,
       DateTime? pFixedAssetSiteTransDate = null,
       int? pAssetId = null,
       int? pSiteDetailId = null,
       int? pTransactionTypeId = null,
       bool? pFixedAssetSiteIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFixedAssetSite.funFixedAssetSiteGET(
            pFixedAssetSiteId: pFixedAssetSiteId,
            pFixedAssetSiteQty: pFixedAssetSiteQty,
            pFixedAssetSiteTransDate: pFixedAssetSiteTransDate,
            pAssetId: pAssetId,
            pSiteDetailId: pSiteDetailId,
            pTransactionTypeId: pTransactionTypeId,
            pFixedAssetSiteIsActive: pFixedAssetSiteIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
