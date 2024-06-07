using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI
{
    public class APISecurityRoleController : ApiController
    {
        private IdbSecurityRole _dbSecurityRole;
        public APISecurityRoleController(IdbSecurityRole dbSecurityRole) {
            _dbSecurityRole = dbSecurityRole;
        }

        [HttpGet]
        public string SecurityRoleGET(
        int? pSecurityRoleId = null,
        string pSecurityRoleNameL1 = null,
        string pSecurityRoleNameL2 = null,
        bool? pIsMaster = null,
        int? pSecurityRoleObjectId = null,
        int? pObjectId = null,
         int? pUserId = null,
        string pObjectAction = null,
        bool? pSecurityRoleIsActive = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set data
            string vData = _dbSecurityRole.funSecurityRoleGET(
            pSecurityRoleId : pSecurityRoleId,
            pSecurityRoleNameL1 : pSecurityRoleNameL1,
            pSecurityRoleNameL2 : pSecurityRoleNameL2,
            pSecurityRoleIsActive : pSecurityRoleIsActive,
            pIsMaster : pIsMaster,
            pSecurityRoleObjectId : pSecurityRoleObjectId,
            pObjectId : pObjectId,
            pUserId: pUserId,
            pObjectAction : pObjectAction,
            pQueryTypeId : pQueryTypeId);
            // Get Data
            return vData;

        }
    }
}
