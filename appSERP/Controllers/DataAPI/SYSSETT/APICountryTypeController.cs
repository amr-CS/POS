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
    public class APICountryTypeController : ApiController
    {
        private IdbCountryType _dbCountryType;
        public APICountryTypeController(IdbCountryType dbCountryType) {
            _dbCountryType = dbCountryType;
        }

        [HttpGet]
        public string CountryTypeGET(
        int? pCountryTypeId = null,
        string pCountryTypeCode = null,
        string pCountryTypeNameL1 = null,
        string pCountryTypeNameL2 = null,
        bool? pCountryTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCountryType.funCountryTypeGET(
            pCountryTypeId : pCountryTypeId,
            pCountryTypeCode : pCountryTypeCode,
            pCountryTypeNameL1 : pCountryTypeNameL1,
            pCountryTypeNameL2 : pCountryTypeNameL2,
            pCountryTypeIsActive : pCountryTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);
            // Result
            return vData;
        }
    }
}
