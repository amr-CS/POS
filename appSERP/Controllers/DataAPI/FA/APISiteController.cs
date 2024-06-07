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
    public class APISiteController : ApiController
    {

        private IdbSite _dbSite;
        public APISiteController(IdbSite dbSite)
        {
            _dbSite = dbSite;
        }


        [HttpGet]
        public string SiteGET(
      int? pSiteId = null,
       string pSiteCode = null,
      string pSiteNameL1 = null,
      string pSiteNameL2 = null,
      string  pSiteLat = null,
      string pSiteLng = null,
       int? pCustomerId = null,
      bool? pSiteIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSite.funSiteGET(
            pSiteId: pSiteId,
            pSiteCode: pSiteCode,
            pSiteNameL1: pSiteNameL1,
            pSiteNameL2: pSiteNameL2,
            pSiteLat:pSiteLat,
            pSiteLng: pSiteLng,
            pCustomerId: pCustomerId,
            pSiteIsActive: pSiteIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
