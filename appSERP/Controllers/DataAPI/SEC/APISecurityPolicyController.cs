using appSERP.appCode.SQL.QueryType;
using appSERP.appCode.dbCode.SEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using appSERP.appCode.dbCode.SEC.Abstract;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APISecurityPolicyController : ApiController
    {
        private IdbSecurityPolicy _dbSecurityPolicy;
        public APISecurityPolicyController(IdbSecurityPolicy dbSecurityPolicy) {
            _dbSecurityPolicy = dbSecurityPolicy;
        }

        [HttpGet]
        public string SecurityPolicyGET(
       int? pSecurityPolicyId = null,
       int? pSecurityPolicySeq = null,
       string pSecurityPolicyNameL1 = null,
       string pSecurityPolicyNameL2 = null,
       bool? pSecurityPolicyIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSecurityPolicy.funSecurityPolicyGET(
            pSecurityPolicyId: pSecurityPolicyId,
            pSecurityPolicySeq: pSecurityPolicySeq,
            pSecurityPolicyNameL1: pSecurityPolicyNameL1,
            pSecurityPolicyNameL2: pSecurityPolicyNameL2,
            pSecurityPolicyIsActive: pSecurityPolicyIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
