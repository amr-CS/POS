using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbTimeZone
    {
        string funTimeZoneGET(
        int? pTimeZoneId = null,
        int? pTimeZoneName = null,
        TimeSpan? pTimeZoneOffset = null,
        bool? pTimeZoneIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);
    }
}
