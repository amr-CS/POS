using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIInvTypeController : ApiController
    {
        private IdbInvType _dbInvType;
        public APIInvTypeController(IdbInvType dbInvType) {
            _dbInvType = dbInvType;
        }

        [HttpGet]
        public string InvTypeGET(
    int? pInvTypeId = null,
        string pInvTypeCode = null,
        string pInvTypeNameL1 = null,
        string pInvTypeNameL2 = null,
        bool? pInvTypeIsActive = true,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbInvType.funInvTypeGET(
            pInvTypeId: pInvTypeId,
            pInvTypeCode: pInvTypeCode,
            pInvTypeNameL1: pInvTypeNameL1,
            pInvTypeNameL2: pInvTypeNameL2,
            pInvTypeIsActive: pInvTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
