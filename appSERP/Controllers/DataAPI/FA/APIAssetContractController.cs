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
    public class APIAssetContractController : ApiController
    {
        private IdbAssetContract _dbAssetContract;
        public APIAssetContractController(IdbAssetContract dbAssetContract) {
            _dbAssetContract = dbAssetContract;
        }

        [HttpGet]
        public  string AssetContractGET(
        int? pAssetContractId = null,
        DateTime? pAssetContractDate = null,
        int? pAssetContractPeriod = null,
        int? pAssetContractRefNo = null,
        decimal? pAssetContractValue = null,
        int? pCurrencyId = null,
        string pAssetContractNote = null,
        int? pAssetContractNo = null,
        int? pFixedAssetCompanyId = null,
        int? pAssetContractPayTypeId = null,
        bool? pAssetContractIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
            string vData = _dbAssetContract.funAssetContractGET(
            pAssetContractId: pAssetContractId,
            pAssetContractDate: pAssetContractDate,
            pAssetContractPeriod: pAssetContractPeriod,
            pAssetContractRefNo: pAssetContractRefNo,
            pAssetContractValue: pAssetContractValue,
            pCurrencyId: pCurrencyId,
            pAssetContractNote: pAssetContractNote,
            pAssetContractNo: pAssetContractNo,
            pAssetContractPayTypeId: pAssetContractPayTypeId,
            pAssetContractIsActive: pAssetContractIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);


            // Get Data
            return vData;

        }
        }
}
