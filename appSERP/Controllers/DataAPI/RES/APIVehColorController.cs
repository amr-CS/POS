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
    public class APIVehColorController : ApiController
    {
        private IdbVehColor _dbVehColor;
        private APIVehColorController(IdbVehColor dbVehColor) {
            _dbVehColor = dbVehColor;
        }
        [HttpGet]
        public string VehColorGET(
            int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVehColor.funVehColorGET(
                pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
