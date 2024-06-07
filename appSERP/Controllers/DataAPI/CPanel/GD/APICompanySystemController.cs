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
    public class APICompanySystemController : ApiController
    {
        private IdbCompanySystem _dbCompanySystem;
        public APICompanySystemController(IdbCompanySystem dbCompanySystem) {
            _dbCompanySystem = dbCompanySystem;
        }

        [HttpGet]
        public string CompanySystemGET(
        int? pCompanySystemId = null,
        string pCompanySystemCode = null,
        int? pAccountId = null,
        int? pCompanyId=null,
        int? pSystemId=null,
        bool? pCompanySystemIsActive = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbCompanySystem.funCompanySystemGET(
            pCompanySystemId : pCompanySystemId,
            pCompanySystemCode : pCompanySystemCode,
            pAccountId : pAccountId,
            pCompanyId: pCompanyId,
            pSystemId: pSystemId,
            pCompanySystemIsActive : pCompanySystemIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
