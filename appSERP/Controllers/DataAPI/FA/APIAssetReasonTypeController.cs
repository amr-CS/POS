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
    public class APIAssetReasonTypeController : ApiController
    {
        private IdbAssetReasonType _dbAssetReasonType;
        public APIAssetReasonTypeController(IdbAssetReasonType dbAssetReasonType) {
            _dbAssetReasonType = dbAssetReasonType;
        }

        [HttpGet]
        public string AssetReasonTypeGET(
         int? pAssetReasonTypeId = null,
         string pAssetReasonTypeNameL1 = null,
         string pAssetReasonTypeNameL2 = null,
         bool? pAssetReasonTypeIsActive = null,
         bool? pIsDeleted = false,
         int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
         string vData = _dbAssetReasonType.funAssetReasonTypeGET(
         pAssetReasonTypeId: pAssetReasonTypeId,
         pAssetReasonTypeNameL1: pAssetReasonTypeNameL1,
         pAssetReasonTypeNameL2: pAssetReasonTypeNameL2,
         pAssetReasonTypeIsActive: pAssetReasonTypeIsActive,
         pIsDeleted: pIsDeleted,
         pQueryTypeId: pQueryTypeId );

            // Get Data
            return vData;
        }
    }
}
