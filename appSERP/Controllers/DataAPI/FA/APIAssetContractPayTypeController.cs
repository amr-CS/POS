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
    public class APIAssetContractPayTypeController : ApiController
    {
        private IdbAssetContractPayType _dbAssetContractPayType;
        public APIAssetContractPayTypeController(IdbAssetContractPayType dbAssetContractPayType) {
            _dbAssetContractPayType = dbAssetContractPayType;
        }

        [HttpGet]
        public  string AssetContractPayTypeGET(
        int? pAssetContractPayTypeId = null,
        string pAssetContractPayTypeNameL1 = null,
        string pAssetContractPayTypeNameL2 = null,
        bool? pAssetContractPayTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
            string vData = _dbAssetContractPayType.funAssetContractPayTypeGET(
            pAssetContractPayTypeId: pAssetContractPayTypeId,
            pAssetContractPayTypeNameL1: pAssetContractPayTypeNameL1,
            pAssetContractPayTypeNameL2: pAssetContractPayTypeNameL2,
            pAssetContractPayTypeIsActive: pAssetContractPayTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Get Data
            return vData;
        }
    }
}
