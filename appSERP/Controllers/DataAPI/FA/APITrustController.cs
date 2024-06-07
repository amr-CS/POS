using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APITrustController : ApiController
    {
        private IdbTrust _dbTrust;
        public APITrustController(IdbTrust dbTrust) {
            _dbTrust = dbTrust;
        }

        [HttpGet]
        public string TrustGET(
        int? pTrustId = null,
        string pTrustNameL1 = null,
        string pTrustNameL2 = null,
        int? pTrustEmployeeId = null,
        string pTrustPhone1 = null,
        string pTrustPhone2 = null,
        string pTrustEmail = null,
        bool? pTrustIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbTrust.funTrustGET(
            pTrustId: pTrustId,
            pTrustNameL1: pTrustNameL1,
            pTrustNameL2: pTrustNameL2,
            pTrustEmployeeId: pTrustEmployeeId,
            pTrustPhone1: pTrustPhone1,
            pTrustPhone2: pTrustPhone2,
            pTrustEmail: pTrustEmail,
            pTrustIsActive: pTrustIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
