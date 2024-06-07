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
    public class APIVehTypeController : ApiController
    {
        private IdbVehType _dbVehType;
        public APIVehTypeController(IdbVehType dbVehType) {
            _dbVehType = dbVehType;
        }

        [HttpGet]
        public string VehTypeGET(
    int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVehType.funVehTypeGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
