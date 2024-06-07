using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserSecurityLog
    {
        string funUserSecurityLogGET(
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
        int? pCompanyId = null,
        bool? pSecurityLogIsActive = null,
        string pDateFrom = null,
        string pDateTo = null,
        string pTimeFrom = null,
        string pTimeTo = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        bool? pIsDeleted = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        DataTable vDTUserLog { get; set; }
    }
}
