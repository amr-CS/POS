using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIAssetDepController : ApiController
    {
        private IdbAssetDep _dbAssetDep;
        public APIAssetDepController(IdbAssetDep dbAssetDep)
        {
            _dbAssetDep = dbAssetDep;
        }

        [HttpGet]
        public string AssetDepGET(
        int? pAssetDepId = null,
        DateTime? pAssetLastDepDate = null,
        DateTime? pAssetDepDate = null,
        bool? pAssetDepIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Value
            string vData = _dbAssetDep.funAssetDepGET(
            pAssetDepId : pAssetDepId,
            pAssetLastDepDate : pAssetLastDepDate,
            pAssetDepDate : pAssetDepDate,
            pAssetDepIsActive : pAssetDepIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            // Return Data
            return vData;
                
        }
    }
}
