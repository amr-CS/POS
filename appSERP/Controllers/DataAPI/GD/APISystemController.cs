using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.dbCode.GD;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.GD
{
    public class APISystemController : ApiController
    {
        private IdbSystem _dbSystem;
        public APISystemController(IdbSystem dbSystem) {
            _dbSystem = dbSystem;
        }

        [HttpGet]
        public string SystemGET(
        int? pSystemId = null,
        string pSystemCode = null,
        string pSystemNameL1 = null,
        string pSystemNameL2 = null,
        string pSystemImageLogo = null,
        string pSystemVersion = null,
        DateTime? pSystemLastUpdated = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSystem.funSystemGET(
            pSystemId: pSystemId,
            pSystemCode: pSystemCode,
            pSystemNameL1: pSystemNameL1,
            pSystemNameL2: pSystemNameL2,
            pSystemImageLogo: pSystemImageLogo,
            pSystemVersion: pSystemVersion,
            pSystemLastUpdated: pSystemLastUpdated,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // RESULT
            return vData;
        }
    }
}
