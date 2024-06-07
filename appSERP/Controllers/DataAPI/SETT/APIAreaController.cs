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
    public class APIAreaController : ApiController
    {

        private IdbArea _dbArea;
        public APIAreaController(IdbArea dbArea) {
            _dbArea = dbArea;
        }

        [HttpGet]
        public string AreaGET(
        int? pAreaId = null,
        string pAreaCode = null,
        string pAreaNameL1 = null,
        string pAreaNameL2 = null,
        int? pCityId = null,
        bool? pAreaIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbArea.funAreaGET(
            pAreaId : pAreaId,
            pAreaCode: pAreaCode,
            pAreaNameL1 : pAreaNameL1,
            pAreaNameL2 : pAreaNameL2,
            pCityId : pCityId,
            pAreaIsActive : pAreaIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId: pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
