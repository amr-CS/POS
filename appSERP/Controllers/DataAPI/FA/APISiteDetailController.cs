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
    public class APISiteDetailController : ApiController
    {
        private IdbSiteDetail _dbSiteDetail;
        public APISiteDetailController(IdbSiteDetail dbSiteDetail) {
            _dbSiteDetail = dbSiteDetail;
        }

        [HttpGet]
        public string SiteDetailGET(
        int? pSiteDetailId = null,
        string pSiteDetailNameL1 = null,
        string pSiteDetailNameL2 = null,
        int? pSiteDetailLat = null,
        int? pSiteDetailLng = null,
        int? pSiteId = null,
        bool? pSiteDetailIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSiteDetail.funSiteDetailGET(
            pSiteDetailId: pSiteDetailId,
            pSiteDetailNameL1: pSiteDetailNameL1,
            pSiteDetailNameL2: pSiteDetailNameL2,
            pSiteDetailLat : pSiteDetailLat,
            pSiteDetailLng : pSiteDetailLng,
            pSiteId : pSiteId,
            pSiteDetailIsActive: pSiteDetailIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
