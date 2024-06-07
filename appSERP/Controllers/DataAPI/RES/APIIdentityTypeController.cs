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
    public class APIIdentityTypeController : ApiController
    {
        private IdbIdentityType _dbIdentityType;
        public APIIdentityTypeController(IdbIdentityType dbIdentityType) {
            _dbIdentityType = dbIdentityType;
        }

        [HttpGet]
        public string IdentityTypeGET(
 int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbIdentityType.funIdentityTypeGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
