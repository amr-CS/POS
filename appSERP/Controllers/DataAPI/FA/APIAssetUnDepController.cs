using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIAssetUnDepController : ApiController
    {
        private IdbAssetUnDep _dbAssetUnDep;
        public APIAssetUnDepController(IdbAssetUnDep dbAssetUnDep)
        {
            _dbAssetUnDep = dbAssetUnDep;
        }

        [HttpGet]
        public string AssetUnDepGET(
        int? pAssetUnDepId = null,
        DateTime? pAssetLastDepDate = null,
        DateTime? pAssetUnDepDate = null,
        bool? pAssetUnDepIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Value
            string vData = _dbAssetUnDep.funAssetUnDepGET(
            pAssetUnDepId: pAssetUnDepId,
            pAssetLastDepDate: pAssetLastDepDate,
            pAssetUnDepDate: pAssetUnDepDate,
            pAssetUnDepIsActive: pAssetUnDepIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Data
            return vData;

        }
    }
}
