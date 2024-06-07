using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APISecurityRoleExceptionController : ApiController
    {
        [HttpGet]
        public string SecurityRoleExceptionGET(
        int? pSecurityRoleExceptionId = null,
         string pSecurityRoleExceptionCode = null,
        string pSecurityRoleExceptionNameL1 = null,
        string pSecurityRoleExceptionNameL2 = null,
        bool? pSecurityRoleExceptionIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
            string vData = dbSecurityRoleException.funSecurityRoleExceptionGET(
            pSecurityRoleExceptionId : pSecurityRoleExceptionId,
            pSecurityRoleExceptionCode: pSecurityRoleExceptionCode,
            pSecurityRoleExceptionNameL1 : pSecurityRoleExceptionNameL1,
            pSecurityRoleExceptionNameL2 : pSecurityRoleExceptionNameL2,
            pSecurityRoleExceptionIsActive : pSecurityRoleExceptionIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            // Get Data
            return vData;
        }
    }
}
