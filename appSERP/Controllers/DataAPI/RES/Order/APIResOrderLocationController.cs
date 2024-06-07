using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES.Order
{
    public class APIResOrderLocationController : ApiController
    {
        private IdbResOrderLocation _dbResOrderLocation;
        public APIResOrderLocationController(IdbResOrderLocation dbResOrderLocation) {
            _dbResOrderLocation = dbResOrderLocation;
        }

        [HttpGet]
        public string ResOrderLocationGET(
        int? pOrderLocId = null,
        int? pOrderId = null,
        int? pCUST_LOC_SEQ = null,
        string pADDRESS = null,
        string pNOTES = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbResOrderLocation.funResOrderLocationGET(
            pOrderLocId : pOrderLocId,
            pOrderId : pOrderId,
            pCUST_LOC_SEQ : pCUST_LOC_SEQ,
            pADDRESS : pADDRESS,
            pNOTES : pNOTES,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            return vData;
        }

        }
}
