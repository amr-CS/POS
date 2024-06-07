using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SETT
{
    public class APICityController : ApiController
    {
        private IdbCity _dbCity;
        public APICityController(IdbCity dbCity) {
            _dbCity = dbCity;
        }

        [HttpGet]
        public string CityGET(
        int? pCityId = null,
           string pCityCode = null,
        string pCityNameL1 = null,
        string pCityNameL2 = null,
        int? pCountryId = null,
        string pCityCenterLat = null,
        string pCityCenterLng = null,
        bool? pCityIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCity.funCityGET(
            pCityId : pCityId,
            pCityCode: pCityCode,
            pCityNameL1 : pCityNameL1,
            pCityNameL2 : pCityNameL2,
            pCountryId : pCountryId,
            pCityCenterLat : pCityCenterLat,
            pCityCenterLng : pCityCenterLng,
            pCityIsActive : pCityIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
