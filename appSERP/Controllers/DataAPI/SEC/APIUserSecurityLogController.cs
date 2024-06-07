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
    public class APIUserSecurityLogController : ApiController
    {

        private IdbUserSecurityLog _dbUserSecurityLog;
        public APIUserSecurityLogController(IdbUserSecurityLog dbUserSecurityLog)
        {
            _dbUserSecurityLog = dbUserSecurityLog;
        }

        [HttpGet]
        public string funUserSecurityLogGET(
        int? pSecurityLogId = null,
        string pSecurityLogLat = null,
        string pSecurityLogLng = null,
        string pSecurityLogLocation = null,
        string pSecurityLogDevice = null,
        bool? pSecurityLogDeviceIsMobile = null,
        DateTime? pSecurityLogDate = null,
        TimeSpan? pSecurityLogTime = null,
        string pOldPassword = null,
        string pNewPassword = null,
        int? pUserId = null,
        int? pUserSecurityTransactionTypeId = null,
        bool? pIsDeleted = false,
        bool? pSecurityLogIsActive = null,
        string pDateFrom = null,
        string pDateTo = null,
        string pTimeFrom = null,
        string pTimeTo = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Data
            string vData = _dbUserSecurityLog.funUserSecurityLogGET(
            pSecurityLogId : pSecurityLogId,
            pSecurityLogLat : pSecurityLogLat,
            pSecurityLogLng : pSecurityLogLng,
            pSecurityLogLocation : pSecurityLogLocation,
            pSecurityLogDevice : pSecurityLogDevice,
            pSecurityLogDeviceIsMobile : pSecurityLogDeviceIsMobile,
            pSecurityLogDate : pSecurityLogDate,
            pSecurityLogTime : pSecurityLogTime,
            pOldPassword : pOldPassword,
            pNewPassword : pNewPassword,
            pUserId : pUserId,
            pUserSecurityTransactionTypeId : pUserSecurityTransactionTypeId,
            pSecurityLogIsActive : pSecurityLogIsActive,
            pDateFrom : pDateFrom,
            pDateTo : pDateTo,
            pTimeFrom : pTimeFrom,
            pTimeTo : pTimeTo,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );
            // Get Data
            return vData;

        }
    }
}
