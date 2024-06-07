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
    public class APIValueTypeController : ApiController
    {
        private IdbValueType _dbValueType;
        public APIValueTypeController(IdbValueType dbValueType) {
            _dbValueType = dbValueType;
        }
        [HttpGet]
        public string ValueTypeGET(
int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbValueType.funValueTypeGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
