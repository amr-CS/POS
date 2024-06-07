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
    public class APIVUnitController : ApiController
    {
        private IdbVUnit _dbVUnit;
        public APIVUnitController(IdbVUnit dbVUnit)
        {
            _dbVUnit = dbVUnit;

        }
        [HttpGet]
        public string VUnitGET(
  int? pCodeId = null,
  int? pORD = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVUnit.funVUnitGET(
           pCodeId: pCodeId,
           pORD: pORD,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
