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
    public class APIExitTypeController : ApiController
    {
        private IdbExitType _dbExitType;
        public APIExitTypeController(IdbExitType dbExitType) {
            _dbExitType = dbExitType;
        }

        [HttpGet]
        public string ExitTypeGET(
int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbExitType.funExitTypeGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
