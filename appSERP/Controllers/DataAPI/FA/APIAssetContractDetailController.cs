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
    public class APIAssetContractDetailController : ApiController
    {

        private IdbAssetContractDetail _dbAssetContractDetail;
        public APIAssetContractDetailController(IdbAssetContractDetail dbAssetContractDetail) {
            _dbAssetContractDetail = dbAssetContractDetail;
        }


        [HttpGet]
        //public string funAssetContractGET(
            public string AssetContractDetailGET(
        int? pAssetContractDetailId = null,
        int? pAssetContractDetailSeq = null,
        int? pAssetContractDetailQty = null,
        int? pAssetContractId = null,
        int? pAssetId = null,
        bool? pAssetContractDetailIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
        string vData = _dbAssetContractDetail.funAssetContractDetailGET(
        pAssetContractDetailId : pAssetContractDetailId,
        pAssetContractDetailSeq : pAssetContractDetailSeq,
        pAssetContractDetailQty : pAssetContractDetailQty,
        pAssetContractId : pAssetContractId,
        pAssetId : pAssetId,
        pAssetContractDetailIsActive : pAssetContractDetailIsActive,
        pIsDeleted : pIsDeleted,
        pQueryTypeId : pQueryTypeId);
            // Get Data
            return vData;
        }
    }
}
