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
    public class APIFixedAssetCompanyTypeController : ApiController
    {
        private IdbFixedAssetCompanyType _dbFixedAssetCompanyType;
        public APIFixedAssetCompanyTypeController(IdbFixedAssetCompanyType dbFixedAssetCompanyType) {
            _dbFixedAssetCompanyType = dbFixedAssetCompanyType;
        }

        [HttpGet]
        public string FixedAssetCompanyTypeGET(
        int? pFixedAssetCompanyTypeId = null,
        string pFixedAssetCompanyTypeCode = null,
        string pFixedAssetCompanyTypeNameL1 = null,
        string pFixedAssetCompanyTypeNameL2 = null,
        bool? pFixedAssetCompanyTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFixedAssetCompanyType.funFixedAssetCompanyTypeGET(
            pFixedAssetCompanyTypeId: pFixedAssetCompanyTypeId,
            pFixedAssetCompanyTypeCode: pFixedAssetCompanyTypeCode,
            pFixedAssetCompanyTypeNameL1: pFixedAssetCompanyTypeNameL1,
            pFixedAssetCompanyTypeNameL2: pFixedAssetCompanyTypeNameL2,
            pFixedAssetCompanyTypeIsActive: pFixedAssetCompanyTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
