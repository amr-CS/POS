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
    public class APIBuyGroupController : ApiController
    {
        private IdbBuyGroup _dbBuyGroup;
        public APIBuyGroupController(IdbBuyGroup dbBuyGroup) {
            _dbBuyGroup = dbBuyGroup;
        }

        [HttpGet]
        public  string BuyGroupGET(
        int? pBuyGroupId = null,
        string pBuyGroupNameL1 = null,
        string pBuyGroupNameL2 = null,
        bool? pBuyGroupIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
        // Get Data
        string vData = _dbBuyGroup.funBuyGroupGET(
        pBuyGroupId : pBuyGroupId,
        pBuyGroupNameL1 : pBuyGroupNameL1,
        pBuyGroupNameL2 : pBuyGroupNameL2,
        pBuyGroupIsActive : pBuyGroupIsActive,
        pIsDeleted : pIsDeleted,
        pQueryTypeId : pQueryTypeId);
            // Set Data
            return vData;
        }
    }
}
