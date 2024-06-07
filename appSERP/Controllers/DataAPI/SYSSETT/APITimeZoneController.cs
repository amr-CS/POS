using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SYSSETT
{
    public class APITimeZoneController : ApiController
    {

        private IdbTimeZone _dbTimeZone;
        public APITimeZoneController(IdbTimeZone dbTimeZone)
        {
            _dbTimeZone = dbTimeZone;
        }

        [HttpGet]
        public string TimeZoneGET(
        int? pTimeZoneId = null,
        int? pTimeZoneName = null,
        TimeSpan? pTimeZoneOffset = null,
        bool? pTimeZoneIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbTimeZone.funTimeZoneGET(
            pTimeZoneId: pTimeZoneId,
            pTimeZoneName: pTimeZoneName,
            pTimeZoneOffset: pTimeZoneOffset,
            pTimeZoneIsActive: pTimeZoneIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

             // Return Data
            return vData;
        }
    }
}
