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
    public class APIFixedAssetMethodController : ApiController
    {
        private IdbFixedAssetMethod _dbFixedAssetMethod;
        public APIFixedAssetMethodController(IdbFixedAssetMethod dbFixedAssetMethod) {
            _dbFixedAssetMethod = dbFixedAssetMethod;
        }

        [HttpGet]
        public string FixedAssetMethodGET(
      int? pFixedAssetMethodId = null,
      string pFixedAssetMethodNameL1 = null,
      string pFixedAssetMethodNameL2 = null,
      bool? pFixedAssetMethodIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFixedAssetMethod.funFixedAssetMethodGET(
            pFixedAssetMethodId: pFixedAssetMethodId,
            pFixedAssetMethodNameL1: pFixedAssetMethodNameL1,
            pFixedAssetMethodNameL2: pFixedAssetMethodNameL2,
            pFixedAssetMethodIsActive: pFixedAssetMethodIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
