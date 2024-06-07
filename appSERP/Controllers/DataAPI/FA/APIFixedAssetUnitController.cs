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
    public class APIFixedAssetUnitController : ApiController
    {
        private IdbFixedAssetUnit _dbFixedAssetUnit;
        public APIFixedAssetUnitController(IdbFixedAssetUnit dbFixedAssetUnit) {
            _dbFixedAssetUnit = dbFixedAssetUnit;
        }

        [HttpGet]
        public string FixedAssetUnitGET(
      int? pFixedAssetUnitId = null,
      string pFixedAssetUnitNameL1 = null,
      string pFixedAssetUnitNameL2 = null,
      bool? pFixedAssetUnitIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFixedAssetUnit.funFixedAssetUnitGET(
            pFixedAssetUnitId: pFixedAssetUnitId,
            pFixedAssetUnitNameL1: pFixedAssetUnitNameL1,
            pFixedAssetUnitNameL2: pFixedAssetUnitNameL2,
            pFixedAssetUnitIsActive: pFixedAssetUnitIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }


    }
}
