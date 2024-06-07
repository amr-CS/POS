using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APIAdminController : ApiController
    {
        [HttpGet]
        public string AccountGET(int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = string.Empty;
            // Return Data
            return vData;
        }
    }
}
