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
    public class APIPortTypeController : ApiController
    {

        private IdbPortType _dbPortType;
        public APIPortTypeController(IdbPortType dbPortType) {
            _dbPortType = dbPortType;
        }
        [HttpGet]
        public string PortTypeGET(
  int? pPortTypeId = null,
      string pPortTypeCode = null,
      string pPortTypeNameL1 = null,
      string pPortTypeNameL2 = null,
      bool? pPortTypeIsActive = true,
   bool? pIsDeleted = false,
   int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbPortType.funPortTypeGET(
            pPortTypeId: pPortTypeId,
            pPortTypeCode: pPortTypeCode,
            pPortTypeNameL1: pPortTypeNameL1,
            pPortTypeNameL2: pPortTypeNameL2,
            pPortTypeIsActive: pPortTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
