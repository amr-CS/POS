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
    public class APIFixedAssetCompanyController : ApiController
    {
        private IdbFixedAssetCompany _dbFixedAssetCompany;
        public APIFixedAssetCompanyController(IdbFixedAssetCompany dbFixedAssetCompany) {
            _dbFixedAssetCompany = dbFixedAssetCompany;
        }
        [HttpGet]
        public string FixedAssetCompanyGET(
       int? pFixedAssetCompanyId = null,
       string pFixedAssetCompanyCode = null,
       string pFixedAssetCompanyNameL1 = null,
       string pFixedAssetCompanyNameL2 = null,
       int? pFixedAssetCompanyTypeId = null,
       bool? pFixedAssetCompanyIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFixedAssetCompany.funFixedAssetCompanyGET(
            pFixedAssetCompanyId: pFixedAssetCompanyId,
            pFixedAssetCompanyCode: pFixedAssetCompanyCode,
            pFixedAssetCompanyNameL1: pFixedAssetCompanyNameL1,
            pFixedAssetCompanyNameL2: pFixedAssetCompanyNameL2,
            pFixedAssetCompanyTypeId: pFixedAssetCompanyTypeId,
            pFixedAssetCompanyIsActive: pFixedAssetCompanyIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
