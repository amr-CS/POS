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
    public class APIVehStatusController : ApiController
    {

        private IdbVehStatus _dbVehStatus;
        public APIVehStatusController(IdbVehStatus dbVehStatus) {
            _dbVehStatus = dbVehStatus;
        }

        [HttpGet]
        public string VehStatusGET(

int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVehStatus.funVehStatusGET(

            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
