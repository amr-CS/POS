using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APIUserLockController : ApiController
    {
        private IdbUserLock _dbUserLock;
        public APIUserLockController(IdbUserLock dbUserLock)
        {
            _dbUserLock = dbUserLock;
        }

        [HttpGet]
        public  string UserLockGET(
            int? pUserLockId = null,
            int? pUserId = null,
            string pDevice = "",
            DateTime? pLastLoginTime = null,
            int? pQueryTypeId = clsQueryType.qSelect)
        {

            // Declaration
            string vUserLock = _dbUserLock.funUserLockGET(
            pUserLockId: pUserLockId,
            pUserId: pUserId,
            pDevice: pDevice,
            pLastLoginTime: pLastLoginTime,
            pQueryTypeId: pQueryTypeId);

            // Execute
            return vUserLock;
        }

    }
}
