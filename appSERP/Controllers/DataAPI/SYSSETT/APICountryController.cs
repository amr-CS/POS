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
    public class APICountryController : ApiController
    {
        private IdbCountry _dbCountry;
        public APICountryController(IdbCountry dbCountry) {
            _dbCountry = dbCountry;
        }

        [HttpGet]
        public string CountryGET(
        int? pCountryId = null,
        string pCountryCode = null,
        string pCountryNameL1 = null,
        string pCountryNameL2 = null,
        string pCountryPhoneCode = null,
        string pCountryNationalityNameL1 = null,
        string pCountryNationalityNameL2 = null,
        string pCountryImage = null,
        int? pCountryTypeId = null,
        bool? pCountryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCountry.funCountryGET(
            pCountryId : pCountryId,
            pCountryCode : pCountryCode,
            pCountryNameL1 : pCountryNameL1,
            pCountryNameL2 : pCountryNameL2,
            pCountryPhoneCode : pCountryPhoneCode,
            pCountryNationalityNameL1 : pCountryNationalityNameL1,
            pCountryNationalityNameL2 : pCountryNationalityNameL2,
            pCountryImage : pCountryImage,
            pCountryTypeId : pCountryTypeId,
            pCountryIsActive : pCountryIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            // Result
            return vData;
        }
    }
}
